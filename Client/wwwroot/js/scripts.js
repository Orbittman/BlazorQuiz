function scrollIntoView(eleID) {
    var e = document.getElementById(eleID);
    if (!!e && e.scrollIntoView) {
        e.scrollIntoView();
        return true;
    }

    return false;
}