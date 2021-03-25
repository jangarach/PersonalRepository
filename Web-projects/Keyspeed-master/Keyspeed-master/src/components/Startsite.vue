<template >
    <div id="Startsite">
        <header class="conteiner">
            <nav>Key speed</nav>
        </header>
        <main id="Startsite">
            <section>
                <div class="jumbotron">
                    <h2><p v-html="Word"></p></h2>
                    <p>Таймер: {{ currentTime }}</p>
                </div>
                <label class="control-label">Параметры:</label>
                <div class="box" >
                    <div class="btn-group" >
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            {{ parametr }} <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" >
                            <li><a href="#" @click="checkparametr('Легкий уровень')">Легкий уровень</a></li>
                            <li><a href="#" @click="checkparametr('Средний уровень')">Средний уровень</a></li>
                            <li><a href="#" @click="checkparametr('Тяжелый уровень')">Тяжелый уровень</a></li>
                            <li role="separator" class="divider"></li>
                        </ul>
                    </div>
                    <p><a class="btn btn-primary btnRun" href="#" role="button" @click="Start" v-bind:class="{'btn-danger':button.vis}">{{ button.Text }}</a></p>
                </div>
                <div class="child">
                    <label class="control-label Text1">Введите текст</label>
                    <textarea class="form-control" rows="3" v-model="KeyWord" v-on:keyup='check'></textarea>
                </div>  
                <div class="child2"></div>  
            </section>
        </main>
        <footer>  
        </footer>
    </div>
</template>
<script>
export default {
    name: "Startsite",
    data(){
        return{
            parametr:'Выберите...',
            TextWords: ['Каждое утро','Еще при свете звезд','Звуки же собственной жизни','Тщательно одетый и причесанный'],
            Word:'Ну что начнем игру?',
            index: 0,
            timer: null,
            timer1: null,
            currentTime: 0,
            button:{
                vis: false,
                Text: 'Начать'
            },
            KeyWord: '',
            chekT: []
        }
    },
    methods:{
        checkparametr: function(name){
            if (name=='Легкий уровень'){
                this.currentTime=20;
            }
            if (name=='Средний уровень'){
                this.currentTime=10;
            }
            if (name=='Тяжелый уровень'){
                this.currentTime=5;
            }
            this.button.Text = 'Начать';     
            return this.parametr = name;
        },
        check(){
                function excludeRight(stopInterval, left, right, timer, timer1, button, Word){
                    if (Word != 'Время вышло!!!'){
                        if (left==right){
                            stopInterval(timer);
                            stopInterval(timer1);
                            button.Text = "Продолжить";
                            button.vis=false;
                        }  
                        left = left.replace(/<[^>]+>/g,'');
                        var substring = left.substring(0,right.length);
                        if (right == substring){                            
                            let str = "<span style=\"color: red\">"+substring+"</span>"+left.substr(right.length);
                            return str;
                        } else {
                            return 'error';
                        }
                    }   
                    else
                        console.log('Хуй');     
                        console.log(Word);        
                }
                this.Word = excludeRight(this.stopInterval, this.TextWords[this.index], this.KeyWord, this.timer, this.timer1, this.button, this.Word)
        },
        Start: function(){ 
               
            if (this.parametr == 'Выберите...'){
                alert('Выбери параметры!')
            }
            else{
                if (this.button.Text == 'Пауза'){
                    this.Word = 'Игра на паузе';
                    this.button.vis=false;
                    this.button.Text = 'Продолжить';
                    this.stopInterval(this.timer);
                    this.stopInterval(this.timer1);        
                }
                else{
                    if (this.button.Text == 'Начать'){
                        this.index = Math.floor(Math.random()*this.TextWords.length);
                        this.button.vis=true;
                        this.button.Text = 'Пауза';
                        this.Word = this.TextWords[this.index];     
                        this.startInterval(this.currentTime);                 
                    }
                    if (this.button.Text == 'Повторить'){
                        this.checkparametr(this.parametr);
                        this.button.vis=true;
                        this.button.Text = 'Пауза';
                        this.Word = this.TextWords[this.index];     
                        this.startInterval(this.currentTime);  
                    }
                    if (this.button.Text == 'Продолжить'){
                        this.button.vis=true;
                        this.button.Text = 'Пауза';
                        this.Word = this.TextWords[this.index];     
                        this.startInterval(this.currentTime);  
                    }
                }  
            }
        },
        startInterval: function(currentTime){
            var p = currentTime;
            this.timer = setInterval(() => {
                this.currentTime--;
            }, 1000);
            this.timer1 = setTimeout(()=>{
                clearInterval(this.timer);
                this.button.vis=false;
                this.button.Text = 'Повторить';
                this.Word = 'Время вышло!!!';
            }, p*1000);
        },
        stopInterval: function(name){
            clearInterval(name);
        },
        checktext: function(){
            
        }
    }
}
</script>
<style>
body{
    margin: 0;
    padding: 0;
}

@media (min-width: 600px) {
    .conteiner{
        z-index: 2;
        position: fixed;
        width: 100%;
        height: 80px;
        background: #E9F4FF; 
        border-bottom:  2px solid #F2F2EA;
    }
    nav{
        padding-top: 25px;
        padding-left: 20px;
        font-family: 'Georgia', serif;
        font-size: 24px;
    }
    section{
        position: relative;
        padding-left: 20%;
        padding-right: 20%;
        height: 1450px;
        background: #FFFFFF;
        top: 100px;
        margin: auto;
    }
    .child2{
        position: fixed;
        width: 100%;
        height: 50px;
        background: #C8CFE8;
        bottom: 0;
        left: 0;
    }
    .jumbotron{
        text-align: center;
        padding-top: 20px;
    }
    .box div{
        float: left;
    }
    .btnRun{
        position: absolute;
        right: 20%;
    }
    .child{
        clear: both;
        padding-top: 30px;
    }
    .TextCheck{
        background: rgb(204, 193, 193);
    }
}
@media (width: 600px){
    .conteiner{
        z-index: 2;
        position: fixed;
        width: 100%;
        height: 80px;
        background: #E9F4FF; 
        border-bottom:  2px solid #F2F2EA;
    }
    nav{
        padding-top: 25px;
        padding-left: 20px;
        font-family: 'Georgia', serif;
        font-size: 24px;
    }
    section{
        position: relative;
        padding-left: 20%;
        padding-right: 20%;
        height: 1450px;
        background: #FFFFFF;
        top: 100px;
        margin: auto;
    }
    .child2{
        position: fixed;
        width: 100%;
        height: 50px;
        background: #C8CFE8;
        bottom: 0;
        left: 0;
    }
    .jumbotron{
        text-align: center;
        padding-top: 20px;
    }
    .box div{
        float: left;
    }
    .btnRun{
        position: absolute;
        right: 20%;
    }
    .child{
        clear: both;
        padding-top: 30px;
    }
    .TextCheck{
        background: rgb(204, 193, 193);
    }
}
</style>

