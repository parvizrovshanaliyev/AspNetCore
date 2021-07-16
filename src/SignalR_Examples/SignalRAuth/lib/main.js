$(document).ready(() => {

    //#region signalR connection
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:5001/chathub")
        .build();
    connection.start();
    //#endregion signalR

    // login olmayibsa elementleri disable olmalidir
    //$(".disabled").attr("disabled", "disabled");


    //$(".disabled").each(
    //    (index, item) => {
    //        item.attr("disabled", "disabled");
    //    });

    $(".disabled").each(function () {
        $(this).attr("disabled", "disabled");
    });
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
        $("#txtNickName").innerHTML = "";
        connection
            .invoke("GetNickNameAsync", nickName)
            .catch(error => console.log(`xeta bas verdi :${error}`));

        // client login olduqdan sonra elementlerin active edilmesi
        //$(".disabled").each(
        //    (index, item) => {
        //        item.removeAttr("disabled");
        //        item.classList.remove("remove");
        //    });

        $(".disabled").each(function () {
            $(this).removeAttr("disabled");

            $(this).removeClass("disabled");
        });
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
    connection.on("ClientsDataAsync", clients => {

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
        const clientNickName = $('.users.active').first().html();
        const message = $("#textAreaMessage").val();

        connection
            .invoke("SendMessageAsync", message, clientNickName)
            .catch(error => console.log(`xeta bas verdi :${error}`));

        const messageItem = $(".message").clone();
        messageItem.removeClass("message");
        messageItem.find("h5")[1].innerHTML = "You";
        messageItem.find("p").html(message);
        $(".messageBox").append(messageItem);
    });
    let _groupNames = "";
    $("#btnSendGroup").click(() => {

        if (_groupNames != "") {

            const message = $("#textAreaMessage").val();
            connection
                .invoke("SendMessageAsync", message, _groupNames[0])
                .catch(error => console.log(`xeta bas verdi :${error}`));

            const messageItem = $(".message").clone();
            messageItem.removeClass("message");
            messageItem.find("h5")[1].innerHTML = "You";
            messageItem.find("p").html(message);
            $(".messageBox").append(messageItem);
        }
        
    });
    /*
     * receive message
     */
    connection.on("receiveMessageAsync", (nickName, message) => {
        //console.log(message);
        const messageItem = $(".message").clone();
        messageItem.removeClass("message");
        messageItem.find("h5")[0].innerHTML = nickName;
        messageItem.find("p").html(message);
        $(".messageBox").append(messageItem);
    });
    /*
     * Create Group
     */
    $("#btnCreateGroup").click(() => {

        const groupName = $("#txtGroupName").val();

        connection
            .invoke("AddGroupAsync", groupName)
            .catch(error => console.log(`xeta bas verdi :${error}`));
    });

    /*
     * Show Groups to all clients
     */

    connection.on("GroupsAsync", (groups) => {

        $("#groups").html("");
        let options = `<option selected="selected" value="-1">Groups</option>`;

        $.each(groups,
            (index, item) => {
                options += `<option  value="${item.name}">${item.name}</option>`;
            });

        $("#groups").append(options);
    });

    /*
     * enter group
     */

    $("#btnEnterSelectedGroup").click(() => {

        let groupNames = [];
        $('#groups option:selected').map((i, e) => {
            groupNames.push(e.innerHTML);
        });

        connection
            .invoke("AddClientToGroupsAsync", groupNames)
            .catch(error => console.log(`xeta bas verdi :${error}`));
    });


    $('#groups').change(function () {
        let groupName = $(this).val();
        _groupNames = groupName;
        connection
            .invoke("GetClientsToGroupAsync", groupName[0])
            .catch(error => console.log(`xeta bas verdi :${error}`));
    });
})