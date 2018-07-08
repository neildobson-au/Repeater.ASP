var renameAttributes = function (oldPrefix, newPrefix, templateSelector) {
    var template = document.querySelector(templateSelector);
    var mapValues = [];

    var elementsWithNames = template.querySelectorAll("[name^='" + oldPrefix + "']");
    elementsWithNames.forEach(function (el) {
        mapValues.push({from:el.getAttribute("name")});
    });

    var elementsWithIds = template.querySelectorAll("[id^='" + oldPrefix + "']");
    elementsWithIds.forEach(function (el) {
        mapValues.push({from:el.getAttribute("id")});
    });

    mapValues.forEach(function (mv) {
        mv.to = getValue(mv.from, oldPrefix, newPrefix);
    });

    var allElements = template.querySelectorAll("*");
    allElements.forEach(function (el) {
        var attributes = el.attributes;
        for (var i = 0; i < attributes.length; i ++)
        {
            var attr = attributes[i];
            mapValues.forEach(function (mv) {
                if (attr.value === mv.from)
                {
                    attr.value = mv.to;
                }
                else if (attr.name === "href" && attr.value.indexOf(mv.from, 1) === 1) {
                    attr.value = "#" + mv.to;
                }
            });
        }
    });
};

var getValue = function (oldValue, oldPrefix, newPrefix) {
    return oldValue.replace(oldPrefix, newPrefix);
};


//renameAttributes("EmptyLocation", "NewLocation", "#EmptyLocation_repeaterRow");

var repeater = function (oldNamePrefix, oldIdPrefix, newNamePrefix, newIdPrefix) {
    // 1. Calculate index by counting descendents with data-repeater-row having same value as newNamePrefix
    // 2. newNamePrefixNth = newNamePrefix[index]
    // 3. newIdPrefixNth = newIdPrefix_index_
    // 3. Clone template
    // 4. Rename attributes by replacing oldNamePrefix & oldIdPrefix with newNamePrefixNth & newIdPrefixNth
    // 5. Insert into DOM
    // 6. Wire event handlers
};

document.addEventListener("DOMContentLoaded", function() {
    var buttons = document.getElementsByClassName("repeater-button");
    for (var i = 0; i < buttons.length; i ++) {
        buttons[i].addEventListener("click", function () {
            var button = this;
            var repeaterContent = button.dataset.repeaterSelector;
        });
    }
});

