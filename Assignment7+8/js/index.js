axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.joke);

        let jokeText = document.querySelector(".joke");
        if (response.data.type == "single") {
            jokeText.innerText = response.data.joke;
        } else {
            jokeText.innerText = response.data.setup + " " + response.data.delivery;
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
            function getJoke() {
                if (response.data.type == "single") {
                    jokeText.innerText = response.data.joke;
                } else {
                    jokeText.innerText = response.data.setup + " " + response.data.delivery;
                }
            }

            setTimeout(getJoke, 4000);

        })
        .catch(function (error) {
            console.log(error);
        });
});
