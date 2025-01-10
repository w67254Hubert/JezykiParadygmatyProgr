open System
open System.Collections.Generic

// Klasa BankAccount
type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Deposit(amount: float) =
        if amount <= 0.0 then
            printf "Kwota wpłaty musi być większa od zera."
        else
            balance <- balance + amount
            printf "\nna konto %s przelano %f" this.AccountNumber amount

    member this.Withdraw(amount: float) =
        if amount <= 0.0 then
            printf "Kwota wypłaty musi być większa od zera."
        elif amount > balance then
            printf "Brak wystarczających środków na koncie."
        else
            balance <- balance - amount
            printf "\nz konta %s zabrano %f" this.AccountNumber amount
           
type Bank() =
    let accounts = Dictionary<string, BankAccount>()

    member this.CreateAccount(accountNumber: string, initialBalance: float) =
        if accounts.ContainsKey(accountNumber) then
             failwith "konto o podanym numerze już istnieje."//nie wiem jak inaczej ma to działać
        else
            let newAccount = BankAccount(accountNumber, initialBalance)
            accounts.Add(accountNumber, newAccount)
            newAccount//zwracana klasa bankAccount 

    member this.GetAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts.[accountNumber]
        else
            failwith "nie znaleziono konta o podanym numerze."

    member this.UpdateAccount(accountNumber: string, newBalance: float) =
        let account = this.GetAccount(accountNumber)
        let difference = newBalance - account.Balance
        if difference > 0.0 then
            account.Deposit(difference)
        else
            account.Withdraw(-difference)
        //ta funkcja powinna być chyba odpowiedzialna za pośredniczenie w tranzakcjach konta
        //a niekoniecznie działać jako nadpisanie salda ;/

    member this.DeleteAccount(accountNumber: string) =
        let removed = accounts.Remove(accountNumber)
        if removed then
            printfn "\nkonto o numerze %s zostało usunięte." accountNumber
        else
            printfn "\nkonto o numerze %s nie istnieje" accountNumber

    member this.CheckAccount(accountNumber: string) =
        let account = this.GetAccount(accountNumber)
        printf "\nsaldo konta %s wynosi %f" accountNumber account.Balance
        
        


// Program główny
[<EntryPoint>]
let main argv =
    let bank = Bank()
    // Tworzenie kont
    let account1 = bank.CreateAccount("123456", 1000.0)
    let account2 = bank.CreateAccount("789012", 2000.0)
    printfn "\nsprawdzenie utworzonych kont"
    bank.CheckAccount("123456")
    bank.CheckAccount("789012")
    // Wpłata na konto
    printfn "\nWpłata 500 PLN na konto 123456:"
    account1.Deposit(500.0)
    bank.CheckAccount("123456")

    // Wypłata z konta
    printfn "\nWypłata 300 PLN z konta 789012:"
    account2.Withdraw(300.0)
    bank.CheckAccount("789012")


    // Aktualizacja konta
    printfn "\nAktualizacja salda konta 123456 do 2500 PLN:"
    bank.UpdateAccount("123456",2500.0)
    bank.CheckAccount("123456")

    // Usunięcie konta
    printfn "\nUsunięcie konta 789012:"
    bank.DeleteAccount("789012")


    printfn "\nProgram zakończył działanie."

    System.Console.ReadLine()

    0
