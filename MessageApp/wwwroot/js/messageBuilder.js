var recentImageBuilder = function () {
    var recentImage = null;
    var image = null;

    return {
        createRecentImage: function (classList) {
            recentImage = document.createElement("div")

            if (classList === undefined)
                classList = [];

            for (var i = 0; i < classList.length; i++) {
                recentImage.classList.add(classList[i])
            }

            recentImage.classList.add('recent-img')
            return this;
        },
        withImage: function (text) {
            image = document.createElement("img")
            image.setAttribute('src', text);
            return this;
        },
        build: function () {
            recentImage.appendChild(image);
            return recentImage;
        }
    }
}

var recentDataBuilder = function () {
    var recentData = null;
    var senderName = null;
    var timeStamp = null;
    var messageText = null;

    return {
        createRecentData: function (classList) {
            recentData = document.createElement("div")

            if (classList === undefined)
                classList = [];

            for (var i = 0; i < classList.length; i++) {
                recentData.classList.add(classList[i])
            }

            recentData.classList.add('recent-data')
            return this;
        },
        withSenderName: function (text) {
            senderName = document.createElement("h3")
            senderName.appendChild(document.createTextNode(text))
            return this;
        },
        withTimeStamp: function (text) {
            timeStamp = document.createElement("span")
            timeStamp.className = 'time'
            timeStamp.appendChild(document.createTextNode(text))
            return this;
        },
        withText: function (text) {
            messageText = document.createElement("span")
            messageText.appendChild(document.createTextNode(text))
            return this;
        },
        build: function () {
            senderName.appendChild(timeStamp);
            recentData.appendChild(senderName);
            recentData.appendChild(messageText);
            return recentData;
        }
    }
}