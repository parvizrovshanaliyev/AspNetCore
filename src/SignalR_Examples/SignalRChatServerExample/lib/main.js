$(document).ready(() => {
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
    //#region signalR
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/chathub")
        .build();
    connection.start();

    /*
      Client To server
     */
    $("#btnLogin").click(() => {
        let nickName = $("#txtNickName").val();

        connection
            .invoke("GetNickNameAsync", nickName)
            .catch(error => console.log(`xeta bas verdi :${error}`));
        $(".disabled").removeAttr("disabled");

    });

    /*
      Server To client
     */
    connection.on("ClientJoinedAsync", nickname => {
        $("#clientStatusMessages").html(`${nickname}: joined`);
        $("#clientStatusMessages").fadeIn(2000, () => {
            setTimeout(() => {
                $("#clientStatusMessages").fadeOut(2000);
            },
                2000);
        });
    });
    connection.on("SendClientsDataAsync", clients => {


        $('#clients').html("");
        $.each(clients,
            (index, item) => {
                $('#clients').append(`<a class='list-group-item list-group-item-action users'>${item.nickName}</a>`);
            });

    });
    //#endregion signalR



})