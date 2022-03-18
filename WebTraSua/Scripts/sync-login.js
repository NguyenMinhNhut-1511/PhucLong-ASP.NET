const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)

var socket = io.connect("http://localhost:3000")

socket.on("connect", function (data) {
    
})