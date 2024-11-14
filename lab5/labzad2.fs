//for i =1 to 5 do
//printfn "wartość i = %d" i

//for i =1 downto 5 do
//printfn "wartość i = %d" i

//rekurencja

let rec sumRec n=
    if n <=0 then 0
    else n+ sumRec(n-1)


//rekurencyjna suma ogonowa

let sumaTail n=
    let rec sumRecTal n acc =
        if n <=0 then acc
        else sumRecTal(n-1) (acc + n)
    sumRecTal n 0


