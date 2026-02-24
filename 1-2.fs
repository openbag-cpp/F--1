open System

let isOdd inputNum = inputNum % 2 <> 0 // функция проверки числа на нечетность

let isNaturalInteger (inputStr: string) = // функция проверки вводимого значения на принадлежность к множеству натуральных чисел 
    match System.Int32.TryParse(inputStr) with
    | (true, convertedStr) when convertedStr > 0 -> true
    | _ -> false

let findLastDigit inputNumber = inputNumber % 10 // функция нахождения последней цифры числа

let rec findMultiplication inputData multiplication hasOneOddDigit = // функция нахождения произведения нечетных цифр числа 
    match inputData, hasOneOddDigit with
    | 0, true -> multiplication
    | 0, false -> 0

    | n, _ when isOdd (n) -> 
        findMultiplication (n / 10) (multiplication * findLastDigit n) true

    | n, oddStatus -> findMultiplication (n / 10) multiplication oddStatus

let rec checkInputData () = // функция для вызова функции по подсчету произведения нечетных цифр числа и проверки корректности ввода 
    printfn "Введите натуральное число(enter - выход) "
    let inputString = Console.ReadLine()

    match inputString with
    | "" -> printfn "Выход"
    | _ when isNaturalInteger inputString ->
        let multiplication = findMultiplication (int inputString) 1 false
        printfn "Произведение нечетных цифр числа %s = %i " inputString multiplication
    | _ ->
        printfn "Введенное значение %s не является натуральным числом. Повторите попытку" inputString
        checkInputData ()

[<EntryPoint>]
let main args =
    checkInputData ()
    0
