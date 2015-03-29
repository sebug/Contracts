module FContracts

open System

type Date = Date of DateTime

type Currency = CHF | EUR

type Contract =
    | One of Date * Currency
    | Zero


let date (ds: string): Date option =
    let couldParse,parsedDate = DateTime.TryParse(ds)
    if couldParse then
        Some <| Date parsedDate
    else
        None

let zero: Contract =
    Zero


