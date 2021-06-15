$(document).ready(() => {
    //#region signalR
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/chathub")
        .withAutomaticReconnect()
        .build();
    start();
    async function start() {
        try {

            await connection.start();
        } catch (error) {

            setTimeout(() => start(), 2000);
        }
    }
    //#endregion signalR

    $(".disabled").attr("disabled", "disabled");


    $('.list-group-item').click(function (e) {
        e.preventDefault();
        $(this).addClass('active').siblings().removeClass('active');
    });

    $("#btnSend").click(() => {
        var x = $(".message").clone();
        x.removeClass("message");
        x.find("h5")[1].innerHTML = "";
        x.find("h5")[0].innerHTML = "";
        $(".message").append(x);
    });


    $("#btnLogin").click(() => {
        let nickName = $("#txtNickName");

    });
})