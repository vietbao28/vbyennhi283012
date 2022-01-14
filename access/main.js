var $ = document.querySelector.bind(document);
var $$ = document.querySelectorAll.bind(document);

const PLAYER_STORAGE_KEY = '';

const playlist = $('.playlist');
const heading = $('header h2');
const audio = $('#audio');
const thumnail = $('.cd-thumb');
const cd = $('.cd');
const playBtn = $('.btn-toggle-play');
const player = $('.player');
const progress = $('#progress');
const prevBtn  = $('.btn-prev');
const nextBtn  = $('.btn-next'); 
const control = $('.control');
const randomBtn = $('.btn-random');
const repeatBtn = $('.btn-repeat');

const app = {
    currentIndex: 0,
    isPlaying: false,
    isRandom: false,
    isRepeat: false,
    isActive: false,
    config: JSON.parse(localStorage.getItem(PLAYER_STORAGE_KEY)) || {},
    songs: [
        {
            name: 'Nhất Hoa Nhất Kiếm',
            singer: 'Lý Hâm Nhất',
            audio: './access/song/song8.mp3',
            image: './access/img/song8.jpg' 
        },
        {
            name: 'Vì Sao Dưới Đáy Bùn',
            singer: '[Tàn Thứ Phẩm] Vì Sao Dưới Đáy Bùn',
            audio: './access/song/song6.mp3',
            image: './access/img/song6.jpg' 
        },
        {
            name: 'Em Hiểu Mà',
            singer: 'Tiểu Thẩm Dương - Thẩm Xuân Dương',
            audio: './access/song/song7.mp3',
            image: './access/img/song7.jpg' 
        },
        {
            name: 'Anh Sẽ Ổn Thôi',
            singer: 'Vương Anh Tú',
            audio: './access/song/song9.mp3',
            image: './access/img/song9.jpg' 
        },
        {
            name: 'Photograph',
            singer: 'Ed Sheeran',
            audio: './access/song/song1.mp3',
            image: './access/img/song1.jpg' 
        },
        {
            name: 'Shape Of You',
            singer: 'Wretch 32, Ed Sheeran',
            audio: './access/song/song2.mp3',
            image: './access/img/song2.jpg'
        },
        {
            name: 'Demons (J.Fla)',
            singer: 'Wretch 32, Ed Sheeran',
            audio: './access/song/song3.mp3',
            image: './access/img/song3.jpg' 
        },
        {
            name: 'Bad Lier',
            singer: 'Feat. Selena Gomez - Charlie Puth',
            audio: './access/song/song4.mp3',
            image: './access/img/song4.jpg' 
        },
        {
            name: 'Rise',
            singer: 'Ed Sheeran',
            audio: './access/song/song5.mp3',
            image: './access/img/song5.jpg' 
        },
    ],
    setConfig: function(key, value) {
        this.config[key] = value;
        localStorage.setItem(PLAYER_STORAGE_KEY, JSON.stringify(app.config));
    },
    loadConfig: function() {
        this.isRandom = this.config.isRandom;
        this.isRepeat = this.config.isRepeat;
        randomBtn.classList.toggle('active', app.isRandom);
        repeatBtn.classList.toggle('active', app.isRepeat);
    },
    defineProperty: function () {
        Object.defineProperty(this, 'currentSong', {
            get: function () {
                return this.songs[this.currentIndex];
            }
        })
    },
    //Xử lý sự kiện
    handleEvents: function() {
        const cdWidth = cd.offsetWidth;
        //Xử lý phóng to thu nhỏ 
        document.onscroll = function() {
            const scrollTop = window.scrollY || document.documentElement.scrollTop;
            const newCdWidth = cdWidth - scrollTop;
            if(newCdWidth > 0) {
                cd.style.width = newCdWidth + 'px';
                control.style.paddingTop = 20 + 'px';
                control.style.marginTop = 0;
            } else if(newCdWidth <= 0){
                cd.style.width = 0;
                control.style.paddingTop = 0;
                control.style.marginTop = -10 + 'px';
            }
            cd.style.opacity = newCdWidth / cdWidth;
        }
        //Xử lý play
        playBtn.onclick = function() {
            if(app.isPlaying) {
                audio.pause();
            } else {
                audio.play();
            }
        }
        audio.onplay = function() {
            audio.play();
            app.isPlaying = true;
            player.classList.add('playing');
            thumnailEnimate.play();
            app.activeSong();
        }
        //Dừng
        audio.onpause = function() {
            app.isPlaying = false;
            audio.pause();
            player.classList.remove('playing');
            thumnailEnimate.pause();
        }
        //Xử lý thời gian bài hát
        audio.ontimeupdate = function() {
            if(audio.duration) {
                const progressPercent = Math.floor(audio.currentTime / audio.duration * 100);
                progress.value = progressPercent;
                app.countTimeInProcess();
            }
        }
        //Đĩa quay
        const thumnailEnimate = thumnail.animate([
            {transform: 'rotate(360deg)'}
        ], {
            duration: 10000,
            iterations: Infinity
        })
        thumnailEnimate.pause();
        progress.onchange = function() {
            const seekTime = progress.value / 100 * audio.duration;
            audio.currentTime = seekTime;
        }
        //Next bài
        nextBtn.onclick = function() {
            if(app.isRandom) {
                app.randomSong();
            } else {
                app.nextSong();
            }
            app.activeSong();
            audio.play();
        }
        //Prev Bài
        prevBtn.onclick = function() {
            if(app.isRandom) {
                app.randomSong();
            } else {
                app.prevSong();
            }
            app.activeSong();
            audio.play();
        }
        //Random
        randomBtn.onclick = function() {
            app.isRandom = !app.isRandom;
            app.setConfig('isRandom', app.isRandom);
            randomBtn.classList.toggle('active', app.isRandom);
        }
        //Repeat
        repeatBtn.onclick = function() {
            if(app.isRepeat) {
                repeatBtn.classList.remove('active');
                repeatBtn.classList.add('no-active');
                app.isRepeat = false;
            } else {
                repeatBtn.classList.add('active');
                repeatBtn.classList.remove('no-active');
                app.isRepeat = true;
            }
            app.setConfig('isRepeat', app.isRepeat);
        }
        //Tự chạy bài tiếp theo khi ended
        audio.onended = function() {
            if(app.isRepeat) {
                audio.play();
            } else if(app.isRandom){
                app.randomSong()
            } else {
                app.nextSong();
            } 
            audio.play();
        }
        //Xử lý khi click vào song
        playlist.onclick = function(e) {
            const songNode = e.target.closest('.song:not(.active)');
            if(songNode || e.target.closest('.option')) {
                if(songNode) {
                    app.currentIndex = Number(songNode.dataset.index);
                    app.loadCurrentSong();
                    app.activeSong();
                    audio.play();
                }
            }
        }
    },
    countTimeInProcess: function() {
        const timeCurrentSong = Math.floor(audio.currentTime);
        const audioTime = Math.floor(audio.duration);
        const min_right = Math.floor(audioTime / 60);
        const sec_right = Math.floor(((audioTime / 60) - Math.floor(audioTime / 60)) * 60);
        const min_left = Math.floor(audio.currentTime / 60);;
        const sec_left = Math.floor(((timeCurrentSong / 60) - Math.floor(timeCurrentSong / 60)) * 60);
        progress.classList.add('.smooth');
        $('.end-time').textContent = `${min_right}:${sec_right}`;
        $('.start-time').textContent =`0${min_left}:${sec_left < 10 ? '0' : ''}${sec_left}`
    },
    activeSong: function() {
        const songArray = $$('.song');
        songArray.forEach(function(nowSong) {
            nowSong.classList.remove('active');
        });
        songArray.forEach(function(nowSong, index) {
            if(app.currentIndex === index) {
                nowSong.classList.add('active');
                if(index > 2) {
                    setTimeout(function() {
                        nowSong.scrollIntoView({
                            behavior: 'smooth',
                            block: 'center'
                        });
                    }, 200)
                } else if(index < 3) {
                    setTimeout(function() {
                        nowSong.scrollIntoView({
                            behavior: 'smooth',
                            block: 'end'
                        });
                    }, 200)
                }
            }
        })
    },
    //Hàm xử lý random
    randomSong: function() {
        let prevRandom;
        do {
            prevRandom = Math.floor(Math.random() * app.songs.length);
        } while (prevRandom === this.currentIndex);
        this.currentIndex = prevRandom;
        this.loadCurrentSong();
    },
    //Hàm xử lý khi next
    nextSong: function() {
        this.currentIndex++;
        if(this.currentIndex >= this.songs.length) {
            this.currentIndex = 0;
        }
        this.loadCurrentSong();
    },    
    //Hàm xử lý khi prev
    prevSong: function() {
        this.currentIndex--;
        if(this.currentIndex < 0) {
            this.currentIndex = this.songs.length - 1;
        }
        this.loadCurrentSong();
    },
    //Load bài 
    loadCurrentSong: function() {
        heading.textContent = this.currentSong.name;
        thumnail.style.backgroundImage = `url('${this.currentSong.image}')`;
        audio.src = this.currentSong.audio;
    },
    //Render bài hát
    render: function() {
        const html = this.songs.map((song, index) => {
            return `
            <div class='song ${index == 0 ? 'active' : ''}' data-index='${index}'>
            <div class='thumb' style='background-image: url(${song.image})'></div>
            <div class='body'>
            <h3 class='name'>${song.name}</h3>
            <p class='author'>${song.singer}</p>
            </div>
            <div class='option'>
            <i class='fas fa-ellipsis-h'></i>
            </div>
            </div>
            `
        })
        playlist.innerHTML = html.join('');
    },
    start: function() {
        this.loadConfig();
        this.defineProperty();
        this.handleEvents();
        this.loadCurrentSong();
        this.render();
    }
}
app.start();
