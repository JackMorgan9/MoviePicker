var actorBox = document.getElementById("search-actor");
var genreBoxDefault = document.getElementById("search-genre-default");
var genreBox = document.getElementById("search-genre");
var yearBox = document.getElementById("search-year");
var errorMessage = document.getElementById("error-message");
var typeBox = document.getElementById("type-box");
var actorText = document.getElementById("actor-text");
var rating = document.getElementsByClassName("vote-text");
var ratingContainer = document.getElementsByClassName("movie-vote-container");

function voteText() {

    for (var i = 0, len = ratingContainer.length; i < len; i++) {
        if (parseFloat(rating[i].innerHTML) >= 7) {
            ratingContainer[i].classList.add('green-glow');
        }
        else if (parseFloat(rating[i].innerHTML) < 4) {
            ratingContainer[i].classList.add('red-glow');
        }
        else
            ratingContainer[i].classList.add('amber-glow');
    }
}

voteText();

typeBox.addEventListener('change', function () {
    if (typeBox.value == "tv") {
        actorBox.hidden = true;
        actorText.hidden = true;
    }
    else {
        actorBox.hidden = false;
        actorText.hidden = false;
    }
})

actorBox.addEventListener('keyup', function () {
    if (actorBox.value != "") {
        genreBoxDefault.textContent = "--Optional--"
        yearBox.placeholder = "Optional"
    }
    else {
        SetRequired();
    }
})

genreBox.addEventListener('change', function () {
    if (genreBox.value != "") {
        actorBox.placeholder = "Optional"
        yearBox.placeholder = "Optional"
        genreBoxDefault.text = "--Optional--"
    }
    else {
        SetRequired();
    }
})

yearBox.addEventListener('keyup', function () {
    if (yearBox.value != "") {
        genreBoxDefault.textContent = "--Optional--"
        actorBox.placeholder = "Optional"
    }
    else {
        SetRequired();
    }
})

function SetRequired() {
    if (yearBox.value == "" && genreBox.value == "" && actorBox.value == "") {
        genreBoxDefault.textContent = "--Required--"
        yearBox.placeholder = "Required"
        actorBox.placeholder = "Required"
    }
}

function validate() {
    if (yearBox.value == "" && genreBoxDefault.textContent == "--Required--" && actorBox.value == "") {
        alert("At least one field required!");
        return false;
    }
    else
        return true;
}

