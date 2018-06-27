var repeater = function(selector, oldPrefix, newPrefix) {
    $(selector).find("*").each(function() {
        $.each(this.attributes,
            function(i, attrib) {
                if (!attrib.value.startsWith("EmptyLocation")) return;

                console.debug(attrib.value);
            });
    });
};

repeater("#EmptyLocation_repeaterRow");
