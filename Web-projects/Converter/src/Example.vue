<template>
    <div id='Example'>
        <div class="container-fluid bg-dark" >
            <div class="row logo">
                <div class="col-9 ">
                    <h2>Конвертер валют</h2> 
                </div>
                <div class="col-1 text-center">
                    <a href="#">Конвертер</a> 
                </div>
                <div class="col-2 text-center">
                    <a href="#">Валюты</a> 
                </div>
            </div>
        </div>
        <div class="row cont">
            <div class="col-2 cont1">
                <label for="exampleFormControlSelect1">Выберите валюту:</label>
                <select class="form-control form-width" id="exampleFormControlSelect1" v-model="selected" >
                    <option v-for="(val, index) in info" :key="index"> {{ index }} </option>
                </select>
            </div>
            <div class="col-1 icon">
                <img src="./assets/icon.png" alt="image">
            </div>
            <div class="col-2">
                <label for="exampleFormControlSelect1">Выберите валюту:</label>
                <select class="form-control" id="exampleFormControlSelect1" v-model="seld2" v-on:click="ClickSelected">
                    <option v-for="(val, index) in info1" :key="index">{{ index }} {{ val }}</option>
                </select>
            </div>
            <div class="col-2">
                <label for="exampleFormControlSelect1">Введите сумму:</label>
                <input type="text" class="form-control" placeholder="Сумма..." v-model="text" v-on:keyup.enter="submit">
            </div>
        </div>
        <div class="row text-center zakladki">
            <div class="col-5 col1">
                <div v-if="text!=0">
                    <p>{{ text }} {{selected}} = </p>
                    <p>{{parseFloat(seld2.slice(seld2.lastIndexOf(" ")), seld2.legth)*text | currencydecimal }} {{ seld2.slice(0,3)}}</p>
                </div>
            </div>
            <div class="col-2 col2 link">
                <a href="#" class=" " v-on:click="add_zakladki">Добавить в закладки</a>
            </div>
        </div>
        <div class="add_zakladki">
            <ul class="list_zakladki">
                <li v-for="(val, index) in zakladki" :key="index">
                    <a>
                        {{val}}
                        <img src="src/icons/delete.png" v-on:click="clear_zakladki(index)">
                    </a> 
                    
                </li>
            </ul>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import VueAxios from 'vue-axios'
export default {
    name: 'Example',
    data(){
        return{
            info:[],
            info1:[],
            zakladki:[],
            selected: '', 
            seld2:'',
            text: 0,
            summ: 0,
            urlAPI:'https://api.ratesapi.io/api/latest?base='
        };
    },
    filters: {
        currencydecimal(value) {
            return value.toFixed(2);
        }
    },
    mounted(){
        axios
            .get('https://api.ratesapi.io/api/latest?')
            .then(response => (
                this.info = response.data.rates
                // console.log(response.data)
            ))
    },
    methods: {
        ClickSelected: function(){
            if (this.selected=="")
            {
                alert("Выберите конвертируемую валюту!")
            }
            else{
                axios 
                    .get(this.urlAPI+this.selected)
                    .then(response => (
                        this.info1 = response.data.rates
                        
                    ))
                // console.log(this.value)
                // console.log(this.info1)
                return this.info1
            }
        },
        add_zakladki: function(){
            
            this.zakladki.push(this.text+" "+this.selected+" "+this.seld2+" = "+this.text)
        },
        clear_zakladki: function(index){
            this.zakladki.splice(index, 1);
        }
    }
};

</script>

<style>

.logo {
    padding-top: 10px; 
    color: rgb(170, 170, 170);
}
.logo .text-center {
    padding-top: 15px; 
}
.logo .text-center a{
    color: rgb(255, 255, 255);
}
.logo .text-center a:hover{
    background: rgb(129, 128, 128);
    width: 35px;
    height: 35px;
}
.container-fluid .row{
    height: 80px;
}
.col{
    min-width: 100%;
}
.cont{
    padding-top: 20px;
    padding-left: 100px;
}
.cont select{
    width: 150px;
}
.cont .icon{
    padding-top: 32px;   
}
.icon img{
    width: 38px;
    height: 38px;
}
.zakladki{
    padding-top: 20px; 
    padding-left: 115px; 
    display: table;
}
.zakladki .col1{
    display: table-cell;
    background-color: #F3F5E9;
    width: 500px;
    height: 300px;
}
.zakladki .col2{
    display: table-cell;
    vertical-align: middle;
    border: 2px solid #E4E6DA;
    width: 200px;
    height: 300px;
}
.zakladki .col2:hover{
    background: #F1F7F0;
}
.add_zakladki{
    margin-top: 25px;
    margin-left: 100px;
    width: 700px;
    height: 200px;
    background: #F1F7F0;
    padding-left: 10px;
    padding-top: 10px;
}
.list_zakladki ul{
    margin-left: 10px;
}
.list_zakladki li{
    display: inline;
    list-style: none;
    margin-right: 20px;
}
.list_zakladki li a{
    background: white;
    padding-bottom: 5px;
}
.list_zakladki li img{
    margin: 0px;
    background: rgb(186, 187, 186);
    width: 26px; 
    height: 26px;
    padding-top: 0px;
}
.list_zakladki li img:hover{
    background: rgb(115, 119, 115);
    width: 26px; 
    height: 26px;
}
/* .list_zakladki li img{
    width: 48px;
    height: 48px;
} */

</style>
