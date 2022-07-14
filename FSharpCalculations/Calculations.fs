namespace FSharpCalculations

module Calculations = 
    type Quality = 
        | Good
        | Uncertain
        | Bad

    let density (refDensity: double) (vcl: double) = refDensity * vcl

    let quality quality1 quality2 =
        match (quality1, quality2) with
        | (Bad, _) | (_, Bad) -> Bad
        | (Uncertain, _) | (_, Uncertain) -> Uncertain
        | (Good, Good) -> Good

    type Attribute = {Value: double; Quality: Quality}

    let calculateAttribute a1 a2 formula = 
        let value = 
            (a1.Value, a2.Value)
            ||> formula
        let quality =
            (a1.Quality, a2.Quality)
            ||> quality
        let a3 = {Value = value; Quality = quality}
        a3


