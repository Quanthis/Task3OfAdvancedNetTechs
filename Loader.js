function Load(res)
{
    res += "?";
    for (key in params)
        res += `${key}=${params[key]}`;

    return function (action)
    {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function ()
        {
            if (this.readyState == 4 && this.status == 200)
            {
                action(this.responseText);
            }
        };
        xhttp.open("GET", res, true);
        xhttp.send();
    }
}


function Log(content)
{
    console.log(JSON.parse(content));
}


function Add(where)
{
    return function (content)
    {
        let obj = JSON.parse(content);
        console.log(obj);
        if (obj !== null)
        {
            params.id += 1;

            let div = document.getElementById(where);
            div.innerHTML += "<p>Post ID: " + obj.postID + "</p>";
            div.innerHTML += "<p>Profile ID: " + obj.profileID + "</p>";
            div.innerHTML += "<p>mail: " + obj.mail + "</p>";
            div.innerHTML += "<p>name: " + obj.Name + "</p>";
            div.innerHTML += "<p>avatar: " + obj.avatar + "</p>";
            div.innerHTML += "<p>footer: " + obj.footer + "</p>";
            div.innerHTML += "<p>content: " + obj.content + "</p>";
            div.innerHTML += "<p>answers: " + obj.answers + "</p>";

            where.appendChild(div);
        }
        else
        {
            Console.log("There is nothing more to write...");
        }
    }
}