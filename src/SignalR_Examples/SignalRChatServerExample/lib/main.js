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
    
    /*
      Client To server
     */
    $("#btnLogin").click(() => {
        let nickName = $("#txtNickName");
        connection.invoke("GetNickName",nickName)
            .catch(error=>console.log(error));
    });
     
    /*
      Server To client
     */
    connection.on("ClientJoined",nickname=>{
        $("#clientStatusMessages").html(`${nickname}: joined` )
           $("#clientStatusMessages").fadeIn(2000,()=>{
                setTimeout(()=> {
                    $("#clientStatusMessages").fadeOut(2000);
                },2000)
           })  ;
    });
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


   
})