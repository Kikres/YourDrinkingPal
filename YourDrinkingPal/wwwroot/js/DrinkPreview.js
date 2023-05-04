const id = document.querySelector(".confirm-container").id;
const spinner = document.querySelector(".confirm-spinner");
const blurContainer = document.querySelector(".confirm-blur");
const buttonSubmit = document.querySelector(".confirm-submit");
const inputs = document.querySelectorAll(".confirm-input");

function Startup() {
    fetch(`https://localhost:7132/api/GeneratedImage/${id}`)
        .then((resp) => resp.json())
        .then((data) => {
            console.log(data);
            for (let index = 0; index < data.variations.length; index++) {
                const element = data.variations[index];
                var confirmInput = inputs[index];

                const templateInput = confirmInput.querySelector("input");
                const templateImage = confirmInput.querySelector("img");

                templateImage.src = element.imageUrl;
                templateInput.value = element.id;

                templateImage.addEventListener("click", (event) => {
                    buttonSubmit.textContent = "publicera";
                    buttonSubmit.disabled = false;
                });
            }

            spinner.remove();
            blurContainer.classList.remove("blur");
        })
        .catch((error) => {
            console.log("polling");
            const timeout = 10 * 1000;
            setTimeout(Startup, timeout);
        });
}

Startup();