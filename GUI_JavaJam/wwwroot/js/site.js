// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var time = "Last updated: " + new Date().toLocaleDateString();
    var txtDate = document.getElementById("txtDate");
    txtDate.textContent = time;
});

function pictureClick(musicianName) {
    var imgSource = "/images/"+ musicianName + ".jpg";
    window.open(imgSource);
}

$(".navLink").click(function (event) {
	event.preventDefault();
    var linkUrl = $(this).attr("href");
    $('.content').load("./"+linkUrl);
});


function showMusicians(date) {
    let shortDateString = getDateString(new Date(date));
	let url = (typeof date === "undefined" || date === "")
		? "./api/MusicApi/GetMusicians"
        : "./api/MusicApi/GetMusicians/" + shortDateString;
    var table = document.querySelector("#musicianList");
    table.innerHTML = "";
    fetch(url)
	    .then(
		    function(response) {
                if (response.status !== 200) {
                    let errorMessage = document.createElement("dt");
                    errorMessage.textContent = "No Musicians Could be found";
                    table.append(errorMessage);
				    return;
                }
			    response.json()
				    .then(function(data) {
					    for(var i = 0; i<data.length;i++) {
						    let header = document.createElement("dt");
						    let imageDescription = document.createElement("img");
						    let textDescription = document.createElement("dd");
						    header.textContent = new Date(data[i].timeOfPerformance).toDateString();
						    imageDescription.src = "./images/" + data[i].pictureUrl;
						    textDescription.textContent = data[i].musicianInfo;
						    table.appendChild(header);
						    table.appendChild(imageDescription);
						    table.appendChild(textDescription);
					    }
				    });
		    })
	    .catch(function(err) {
		    console.log("Error happened when fetching data: ", err);
	    });
}

function getDateString(date) {
	let dd = date.getDate();
	let mm = date.getMonth() + 1; //January is 0!

	let yyyy = date.getFullYear();
	if (dd < 10) {
		dd = '0' + dd;
	}
	if (mm < 10) {
		mm = '0' + mm;
	}
	return yyyy + "-" + mm + "-" + dd;
}
