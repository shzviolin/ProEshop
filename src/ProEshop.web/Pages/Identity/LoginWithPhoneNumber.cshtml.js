$(document).ready(function () {
    var minute = parseInt($('div[count-down-timer-minute]').attr('count-down-timer-minute'));
    var second = parseInt($('div[count-down-timer-second]').attr('count-down-timer-second'));
    var countDownTimerInterval = setInterval(coutDown, 1000);
    coutDown();
    function setCountDownTimeBox() {
        $('#count-down-timer-box').html(`${minute}:${second < 10 ? '0' + second : second}`);
    }
    function countDown() {
        if (second == 0) {
            if (second == 0 && minute == 0) {
                alert('done');
                clearInterval(countDownTimerInterval);
            }
            else {
                minute--;
                second = 59;
            }
        }
        else {
            second--;
        }
        var secondToShow = second < 10 ? `0${second}` : second;
        setCountDownTimeBox();
    }
});