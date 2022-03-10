function showDropDown() {
    document.querySelector(".dropdown-content").classList.toggle("show");
}

axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.joke);

        let jokeText = document.querySelector(".joke");
        let delivery = document.querySelector(".punchline");
        if (response.data.type == "single") {
            jokeText.innerText = response.data.joke;
        } else {
            jokeText.innerText = response.data.setup;
            delivery.innerText = response.data.delivery;
        }
        

    })
    .catch(function (error) {
        console.log(error);
    });

document.getElementById("jokeCall").addEventListener("click", function () {
    
    axios({
        method: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
        .then(function (response) {
            console.log(response);
            console.log(response.data.joke);

            let jokeText = document.querySelector(".joke");
            let delivery = document.querySelector(".punchline");
            jokeText.innerText = "";
            delivery.innerText = " ";
            function getJoke() {
                if (response.data.type == "single") {
                    jokeText.innerText = response.data.joke;
                } else {
                    jokeText.innerText = response.data.setup;
                    setTimeout(function () {
                        delivery.innerText = response.data.delivery;
                    }, 4000)                      
                }
            }

            getJoke();

        })
        .catch(function (error) {
            console.log(error);
        });
});
