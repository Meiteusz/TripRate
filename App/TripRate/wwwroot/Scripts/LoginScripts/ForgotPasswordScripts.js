var button = document.getElementById('SendEmail')
var mainBody = document.getElementById('mainBody')
var mainDiv = document.getElementById('mainDiv')
var resetPasswordDiv = document.getElementById('resetPasswordDiv')

mainBody.onload = () => {
    resetPasswordDiv.style.display = 'none'
}

button.onclick = () => {
    mainDiv.style.display = 'none'
    resetPasswordDiv.style.display = 'block'
}