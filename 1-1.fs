open System

let rec makeList currList = // функция заполнения списка значениями на 1 больше чем вводимые значения с проверкой на корректность ввода
    printf "Введите число (enter - выход) "
    let inputData = Console.ReadLine() 
    
    match inputData with
    | "" ->
        printfn "Был введен пустой enter. Выход"
        currList 
    | n -> 
        match System.Int32.TryParse(n) with
        | (true, convValue) -> 
            makeList(currList @ [convValue + 1])
        | (_ , _) -> 
            printfn "Ошибка ввода. Повторите еще раз"
            makeList currList

[<EntryPoint>]
let main args =
    let resList = makeList []
    printfn "Готовый список : %A" resList
    0
