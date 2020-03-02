
var play,
    changefreq,
    oscillator,
    changetype

var oscProp = {
    type: "sine",
    frequency: 400,
    playing: false
}

var audioContext = new AudioContext();
window.onload = function () {
    play = function () {
        if (oscProp.playing) {
            oscillator.stop();
            oscProp.playing = false;
        }
        else {
            oscillator = audioContext.createOscillator();
            oscillator.type = oscProp.type;
            oscillator.frequency.setValueAtTime(oscProp, frequency, audioContext.currentTime);
            oscillator.connect(audioContext.destination);
            oscillator.start();
            oscProp.playing = true;
        }
    }

    changefreq = function{
        oscProp.frequency = document.getElementById("freqslider").value * 50;

        play();
        play();

    }
    changetype = function{
        oscProp.type = document.querySelector("input[name = 'waveform']:checked").value;

        play();
        play();
    }
}