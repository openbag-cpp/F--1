open System

let addElList inputList  = // функция добавления элементов в список
    printfn "Исходный список %A" inputList
    printfn "Введите значение добавляемого элемента"
    let temp = [ Console.ReadLine() ]
    let resultList = inputList @ temp
    resultList

let delElList inputList:list<string> = // функция удаления элемента из списка, который задан с клавиатуры
    printfn "Исходный список %A" inputList
    printfn "Введите значение удаляемого элемента"
    let temp = Console.ReadLine()

    let rec delEl inputList delTarget= // рекурсивная функция удаления элемента из списка 

        match inputList with 
        | [] -> [] // базовый случай
        | head :: tail when head = delTarget -> tail
        | head :: tail -> head :: delEl tail delTarget         

    delEl inputList temp  

let findElList inputList = //функция поиска элемента из списка по заданному ключу -> возвращает список с найденным элементом или пустой список
    printfn "Исходный список %A" inputList
    printfn "Введите искомое значение"
    let target = Console.ReadLine()

    let rec listEl searchList =  
        match searchList with
        | [] -> []
        | head :: tail when head = target -> [head]
        | _ :: tail -> listEl tail
    
    listEl inputList

let mergeLists inputList = // функция сцепки(слияния) двух списков 
    printfn "Исходный список %A" inputList
    printfn "Введите кол-во элементов для заполнения второго списка"
    let tempListLength = int(Console.ReadLine())
    
    let tempList = [ // заполнение второго списка  
        for i in 1..tempListLength do 
            yield (i * 10 |> string) 
    ]     
    printfn "Второй список : %A" tempList
    
    let resultList = inputList@tempList
    resultList
    
let getElList inputList = // функция поиска элемента по индексу 
    printfn "Исходный список %A" inputList
    printfn "Введите номер искомого элемента" 
    let targetNumber = Console.ReadLine()
    
    let rec findElByIndex inputTempList targetIndex = // функция которая возвращает список с элементом с нужным индексом(если такого индекса нет - возвращается пустой список)
        match inputTempList with
        | [] -> []
        | head :: tail -> 
            if targetIndex = 1 then [head]
            else findElByIndex tail (targetIndex - 1) 

    let canMakeOperation = System.Int32.TryParse(targetNumber)
    match canMakeOperation with // проверка возможности сделать операцию 
    | (true , _) -> findElByIndex inputList (int targetNumber) 
    | (_ , _) -> 
        printfn "Ошибка. Введено нечисловое значение"
        []

let rec choice inputList = // функция выбора нужной операции над списком 
    printfn
        "Выберете нужную операцию над списком\n\t1 - добавление элемента\n\t2 - удаление элемента\n\t3 - поиск элемента\n\t4 - сцепка двух списков\n\t5 - получение элемента по номеру\n\t0 - выход"

    let choiseNumber = Console.ReadLine()

    match choiseNumber with // сопоставление с введенным значениям для выбора операции 
    | "0" ->
        printfn "Выход"
        inputList
    | "1" -> addElList inputList  
    | "2" -> delElList inputList
    | "3" -> findElList inputList
    | "4" -> mergeLists inputList
    | "5" -> getElList inputList
    | _ ->
        printfn "Ошибка ввода. Повторите операцию"
        choice inputList


[<EntryPoint>]
let main args =
    let inputList = ["1";"2";"3";"4";"5"] // исходный список 
    let resList = choice inputList
    printfn "Готовый список : %A" resList 
    0
