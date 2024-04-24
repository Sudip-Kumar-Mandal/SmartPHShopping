const micBtn = document.querySelector('#micBtn');
const content = document.querySelector('#speechText');

function speak(sentence) {
    const speech = new SpeechSynthesisUtterance(sentence);

    speech.volume = 1;
    speech.pitch = 1;
    speech.rate = 1;

    window.speechSynthesis.speak(speech);
}

const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
const recognition = new SpeechRecognition();

recognition.onresult = (event) => {
    const current = event.resultIndex;
    const transcript = event.results[current][0].transcript;
    content.textContent = transcript;
    speakThis(transcript.toLowerCase());
}

micBtn.addEventListener('click', () => {
    recognition.start();
})

window.onload = function () {
    setTimeout(() => {
        recognition.start();
    }, 2000);
};


function gotoView(viewName, linkId) {
    const sentence = `Going to ${viewName}`;
    speak(sentence);
    const link = document.querySelector(linkId);
    link.click();
}

function speakThis(message) {

    if (message.includes('hello') || message.includes('hi')) {
        const sentence = 'Hello, how are you?';
        speak(sentence);
    }

    else if (message.includes('go') || message.includes('go to') || message.includes('view')) {
        if (message.includes('home')) {
            gotoView('home', '#CustomerHomeIndexView')
        }
        else if (message.includes('category')) {
            gotoView('category', '#AdminCategoryIndexView')
        }
        else if (message.includes('privacy')) {
            gotoView('privacy', '#CustomerHomePrivacyView')
        }
    }

    else if (message.includes('create category')) {
        const sentence = 'Going to Create Category view';
        speak(sentence);
        const link = document.querySelector('#AdminCategoryCreateView');
        link.click();
    }

    setTimeout(() => {
        recognition.start();
    }, 5000);
}