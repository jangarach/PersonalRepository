var app = new Vue({
    el: '#app',
    data() {
        return {
            newTask: "",
            taskList: []
        } 
    },
    computed: {
        allTask: function() {
            return this.taskList.length
        },
        completeTask: function(){
            let summ = 0
            // 
            for (let i = 0; i<this.taskList.length; i++){
                if (this.taskList[i].chek){
                    summ++
                }
            }
            return summ
        },
        IncompleteTask: function(){
            let summ = 0
            for (let i = 0; i<this.taskList.length; i++){
                if (this.taskList[i].chek==false){
                    summ++
                }
            }
            return summ
        }
    },
    methods:{
        addText: function() {
            let task = this.newTask.trim()
            if (task) {
                this.taskList.push({
                    text: task, 
                    chek: false
                })
            this.newTask = ""    
            }
        },
        cleartask: function() {
            for (let i = 0; i<this.taskList.length; i++){
                if (this.taskList[i].chek){
                    this.taskList.splice(i,1);
                    i=0;
                }
            }
        }
        
    }
});