open System
open System.Collections.Generic

// Klasa BankAccount
type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Deposit(amount: float) =
        if amount <= 0.0 then
            failwith "Kwota wpłaty musi być większa od zera."
        else
            balance <- balance + amount

    member this.Withdraw(amount: float) =
        if amount <= 0.0 then
            failwith "Kwota wypłaty musi być większa od zera."
        elif amount > balance then
            failwith "Brak wystarczających środków na koncie."
        else
            balance <- balance - amount

    override this.ToString() =
        $"Konto: {this.AccountNumber}, Saldo: {this.Balance:F2} PLN"

// Klasa Bank
type Bank() =
    let accounts = Dictionary<string, BankAccount>()

    member this.CreateAccount(accountNumber: string, initialBalance: float) =
        if accounts.ContainsKey(accountNumber) then
            failwith "Konto o podanym numerze już istnieje."
        else
            let newAccount = BankAccount(accountNumber, initialBalance)
            accounts.Add(accountNumber, newAccount)
            newAccount

    member this.GetAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts.[accountNumber]
        else
            failwith "Nie znaleziono konta o podanym numerze."

    member this.UpdateAccount(accountNumber: string, newBalance: float) =
        let account = this.GetAccount(accountNumber)
        account.Deposit(newBalance - account.Balance)

    member this.DeleteAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts.Remove(accountNumber) |> ignore
        else
            failwith "Nie znaleziono konta o podanym numerze."

    member this.PrintAllAccounts() =
        accounts.Values
        |> Seq.iter (fun acc -> printfn "%s" (acc.ToString()))

// Program główny
[<EntryPoint>]
let main argv =
    let bank = Bank()

    // Tworzenie kont
    let account1 = bank.CreateAccount("123456", 1000.0)
    let account2 = bank.CreateAccount("789012", 2000.0)
    printfn "Utworzono konta:"
    bank.PrintAllAccounts()

    // Wpłata na konto
    printfn "\nWpłata 500 PLN na konto 123456:"
    account1.Deposit(500.0)
    bank.PrintAllAccounts()

    // Wypłata z konta
    printfn "\nWypłata 300 PLN z konta 789012:"
    account2.Withdraw(300.0)
    bank.PrintAllAccounts()

    // Aktualizacja konta
    printfn "\nAktualizacja salda konta 123456 do 2500 PLN:"
    bank.UpdateAccount("123456", 2500.0)
    bank.PrintAllAccounts()

    // Usunięcie konta
    printfn "\nUsunięcie konta 789012:"
    bank.DeleteAccount("789012")
    bank.PrintAllAccounts()

    printfn "\nProgram zakończył działanie."
    0
