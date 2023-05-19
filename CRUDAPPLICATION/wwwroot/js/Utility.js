
function requiredTextField(controlId, errorMessage, validationType = "all") {

    var Id = "#txt" + controlId
    var formGroup = "#FormGroup" + controlId
    var errorField = "#err" + controlId

    var txtVal = $(Id).val()
    if (txtVal == "" || txtVal == undefined || txtVal == null) {

        $(formGroup).addClass("error-control")
        $(errorField).addClass("error-control")
        $(errorField).html("Please enter" + errorMessage)
        return false
    }
    else {
        $(formGroup).removeClass("error-control")
        $(errorField).removeClass("error-control")
        $(errorField).html("")
        return true
    }
}

function requiredSelectField(controlId, errorMessage) {

    var Id = "#ddl" + controlId
    var formGroup = "#FormGroup" + controlId
    var errorField = "#err" + controlId

    var ddlVal = $(Id).val()
    if (ddlVal == "-1" || ddlVal == undefined || ddlVal == null || ddlVal == 0) {
        $(formGroup).addClass("error-control")
        $(errorField).addClass("error-control")
        $(formGroup).html("Please select" + errorMessage)
        $(Id).focus()
        return false
    }
    else {
        $(formGroup).removeClass("error-control")
        $(errorField).removeClass("error-control")
        $(formGroup).html("")
        $(Id).focus()
        return true
    }
}
