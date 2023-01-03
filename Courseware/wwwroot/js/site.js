let modal = document.getElementById("SignInModal"),
    signInBtn = document.getElementById("signin"),
    signUpBtn = document.getElementById('signup'),
    closeBtn = document.getElementsByClassName('close')[0],
    closeSignUp = document.getElementsByClassName('close')[1],
    signupModal = document.getElementsByClassName('modal')[1],
    loaderContainer = document.querySelector('.loader-container');

//functions for signin action
signInBtn.addEventListener('click', () => {
    modal.style.display = 'block';
})

closeBtn.onclick = () => {
    modal.style.display = "none";
}

//functions for signup actions
signUpBtn.addEventListener('click', () => {
    signupModal.style.display = 'block'
})

closeSignUp.onclick = () => {
    signupModal.style.display = 'none'
}

window.onclick = (event) => {
    if (event.target == modal || event.target == signupModal) {
        modal.style.display = 'none';
        signupModal.style.display = 'none';
    }
}
