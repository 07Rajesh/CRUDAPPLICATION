$(document).ready(function () {

    $("#btnSignUp").click(function () {
        var isValid = true
        isValid = requiredTextField("Name", " your name")
        if (!isValid) { return isValid }

        isValid = requiredTextField("Email", " your email address")
        if (!isValid) { return isValid }

        isValid = requiredTextField("Password", " your password")
        if (!isValid) { return isValid }

        isValid = requiredSelectField("Gender", " gender")
        if (!isValid) { return isValid }

        isValid = requiredTextField("Mobile", " your mobile number")
        if (!isValid) { return isValid }

        isValid = requiredTextField("Address", " your address")
        if (!isValid) { return isValid }

        console.log(isValid)
    })
})