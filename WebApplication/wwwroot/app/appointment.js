Vue.component("appointment", {
	data: function () {
        return {
            physicians: null,
            specializations: null,
            choosenSpecialization: null,
            choosenPhysician: null,
            date:null,
            physicianForChoose: [],
            id: 1,            
            timeIntervals: null,
            timeInterval:null
			}
		}
    ,
    beforeMount() {
        axios
            .get('http://localhost:49900/appointment/physicians')
            .then(response => {
                this.physicians = response.data
            })
        axios
            .get('http://localhost:49900/appointment/specializations')
            .then(response => {
                this.specializations = response.data
            })
    },
    template: `
        <div>
		    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createAppointment">Create new appointment</button>
            <div class="modal fade" id="createAppointment" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
              <div class="modal-dialog modal-dialog-centered" role="document">
                     <div class="modal-content steps" style="width: 600px;height:500px">
                    <div class="container" align="center">
                        <br/><h4 class="text">Create new appointment</h4><br/>
                        <ul class="nav" role="tablist">
                            <li class="nav-item" style="margin:0 0 0 25px">
                                <button disabled id="step1" class="circleStep circleStepDone">1</button>
                                <h3 class="text">Step 1</h3><br/>
                            </li><h6>______</h6>
                            <li class="nav-item">
                                <button disabled id="step2" disabled class="circleStep circlesStepDisabled">2</button>
                                <h3 class="text">Step 2</h3><br/>
                            </li><h6>______</h6>
                            <li class="nav-item">
                                <button disabled id="step3" disabled class="circleStep circlesStepDisabled">3</button>
                                <h3 class="text">Step 3</h3><br/>
                            </li><h6>______</h6>
                            <li class="nav-item">
                                <button disabled id="step4" disabled class="circleStep circlesStepDisabled">4</button>
                                <h3 class="text">Step 4</h3><br/>
                            </li>
                        </ul></br>
                      </div>                   
                        <div>
                            <div class="tab-content">
    	                        <div id="step1" class="container tab-pane active" v-if="id==1"></br>
                                    <label>Choose date:</label></br>
                                    <input id="date" type="date" v-model ="date"></input>
                                    </br></br></br></br>
                                    <button class="btn btnNext" v-on:click="NextStep()">Next</button>
                                 </div>
    	                        <div id="step2" class="container tab-pane active" v-if="id==2"></br>
                                    <label>Choose  specialization:</label></br>
                                    <select class="select" v-model="choosenSpecialization">
                                        <option disabled>Please select one</option>
                                        <option v-for="s in specializations">{{s.name}}</option>
                                    </select>
                                    </br></br></br></br>
                                    <button class="btn btnPrev" v-on:click="PreviousStep()">Previous</button>
                                    <button class="btn btnNext" v-on:click="NextStep()">Next</button>
                                 </div>
    	                        <div id="step3" class="container tab-pane active" v-if="id==3"></br>
                                    <label>Choose physician:</label></br>
                                    <select class="select" v-model="choosenPhysician">
                                         <option disabled selected="selected">Please select one</option>
                                         <option v-for="p in physicianForChoose" v-bind:value="p">{{p.fullName}}</option>                                        
                                    </select>
                                    </br></br></br></br>
                                    <button class="btn btnPrev" v-on:click="PreviousStep()">Previous</button>
                                    <button class="btn btnNext" v-on:click="NextStep()">Next</button>
                                </div>
                                <div id="step4" class="container tab-pane active" v-if="id==4"></br>                                 
                                    <label>Choose  time:</label></br>
                                    <select class="select" v-model ="timeInterval">
                                        <option div  v-for="t in timeIntervals" v-bind:value="t">{{t.time}}</option>
                                    </select>
                                    </br></br></br></br>
                                    <button class="btn btnPrev" v-on:click="PreviousStep()">Previous</button>
                                    <button class="btn btnNext" v-on:click="MakeAppointment()">Submit</button>
                                </div></br>
                           </div>
                        </div>
                    </div>
                </div>
          </div>
     </div>
	`,
    methods: {
        NextStep: function () {
            if (this.Validation()) {
                if (this.id == 2)
                    this.SpecialistForChoose()
                if (this.id == 3)
                    this.GetTimeIntervals()
                this.id += 1
                this.Steps()
            }
        },
        GetTimeIntervals: function () {
            axios
                .get('http://localhost:49900/appointment/appointments', { params: { physicianId: this.choosenPhysician.id, specializationName: this.choosenSpecialization, date: this.date } })
                .then(response => {
                    this.timeIntervals = response.data
                })
            },
        PreviousStep: function () {
            this.id -= 1
            this.Steps()
        },
        Steps: function () {
            if (this.id == 1) {
                document.getElementById("step1").className = "circleStep circleStepDone"
                document.getElementById("step2").className = "circleStep circlesStepDisabled"
                document.getElementById("step3").className = "circleStep circlesStepDisabled"
                document.getElementById("step4").className = "circleStep circlesStepDisabled"
            }
            else if (this.id == 2) {
                document.getElementById("step1").className = "circleStep circleStepDone"
                document.getElementById("step2").className = "circleStep circleStepDone"
                document.getElementById("step3").className = "circleStep circlesStepDisabled"
                document.getElementById("step4").className = "circleStep circlesStepDisabled"
            }
            else if (this.id == 3) {
                document.getElementById("step1").className = "circleStep circleStepDone"
                document.getElementById("step2").className = "circleStep circleStepDone"
                document.getElementById("step3").className = "circleStep circleStepDone"
                document.getElementById("step4").className = "circleStep circlesStepDisabled"
            }
            else {
                document.getElementById("step1").className = "circleStep circleStepDone"
                document.getElementById("step2").className = "circleStep circleStepDone"
                document.getElementById("step3").className = "circleStep circleStepDone"
                document.getElementById("step4").className = "circleStep circleStepDone"
            }
        },
        SpecialistForChoose: function () {
            this.physicianForChoose = []
            for (p in this.physicians) {
                for (s in this.physicians[p].specializations) {
                    if (this.physicians[p].specializations[s].name == this.choosenSpecialization)
                        this.physicianForChoose.push(this.physicians[p])
                }
            }
        },
        Validation: function () {
            if (this.id == 1 && document.getElementById("date").value != "") {
                return true
            }
            else if (this.id == 2 && this.choosenSpecialization != null) {
                return true
            }
            else if (this.id == 3 && this.choosenPhysician != null) {
                return true
            }
            return false
        },
        MakeAppointment: function () {
            if (this.timeInterval!=null)
                axios
                    .post('http://localhost:49900/appointment/makeAppointment/' + this.choosenPhysician.id + '/' + this.timeInterval.id + '/' + this.date)
                    .then(response => {
                        this.Refresh()
                        alert("Appointment is made")
                    })
                    .catch(error => {
                        alert("Error")
                    })
        }
        },
        Refresh: function () {
            location.reload();
        }
    }
});