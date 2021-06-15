$(document).ready(() => {

    //#region signalR connection
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/chathub")
        .build();
    connection.start();
    //#endregion signalR

    // login olmayibsa elementleri disable olmalidir
    $(".disabled").attr("disabled", "disabled");

    // added active class to item
    //$("body").on("click",".list-group-item",function (e) {
    //    e.preventDefault();
    //    $(this).addClass('active').siblings().removeClass('active');
    //});
    $("body").on("click", ".users", function (e) {
        e.preventDefault();
        $(".users").each(
            (index, item) => {
                item.classList.remove("active");
            });
        $(this).addClass("active");
    });
    /*
      Login :Client To server
     */
    $("#btnLogin").click(() => {
        let nickName = $("#txtNickName").val();

        connection
            .invoke("GetNickNameAsync", nickName)
            .catch(error => console.log(`xeta bas verdi :${error}`));

        // client login olduqdan sonra elementlerin active edilmesi
        $(".disabled").removeAttr("disabled");

    });

    /*
      Alert : Others ,Server To client
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

    // client list
    connection.on("SendClientsDataAsync", clients => {

        $('#clients').html("");
        $.each(clients,
            (index, item) => {
                $('#clients').append(`<a class='list-group-item list-group-item-action users'>${item.nickName}</a>`);
            });
    });

    /*
     * Send Message
     */
    $("#btnSend").click(() => {
        //var x = $(".message").clone();
        //x.removeClass("message");
        //x.find("h5")[1].innerHTML = "";
        //x.find("h5")[0].innerHTML = "";
        //$(".message").append(x);
        const clientNickName=$('.users.active').first().html();
        const message = $("#textAreaMessage").val();

        connection
            .invoke("SendMessageAsync", message,clientNickName)
            .catch(error => console.log(`xeta bas verdi :${error}`));

        const messageItem = $(".message").clone();
        messageItem.removeClass("message");
        messageItem.find("h5")[1].innerHTML="You";
        messageItem.find("p").html(message);
        $(".messageBox").append(messageItem);
    });

    /*
     * receive message
     */
    connection.on("receiveMessageAsync",(nickName,message) => {
        //console.log(message);
        const messageItem = $(".message").clone();
        messageItem.removeClass("message");
        messageItem.find("h5")[0].innerHTML=nickName;
        messageItem.find("p").html(message);
        $(".messageBox").append(messageItem);
    });
})