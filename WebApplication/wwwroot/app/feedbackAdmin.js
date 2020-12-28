Vue.component("feedbackAdmin", {
    data: function () {
        return {
            approvedFeedbacks: null,
            disapprovedFeedbacks: null,
            patients: null
        }
    },
    beforeMount() {
        axios
            .get('/feedback/approved')
            .then(response => {
                this.approvedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('/feedback/disapproved')
            .then(response => {
                this.disapprovedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('/patient/all')
            .then(response => {
                this.patients = response.data
            })
            .catch(error => {
                alert(error)
            })
    },
    template: `
    <div id = "feedbackAdmin">
        <div class= "container">
                <br/><h3 class="text">Feedbacks</h3><br/>
	                            <ul class="nav nav-tabs" role="tablist">
    	                            <li class="nav-item">
    		                            <a class="nav-link active .cards" data-toggle="tab" href="#approvedF">Approved</a>
    	                            </li>
    	                            <li class="nav-item">
    		                            <a class="nav-link .cards" data-toggle="tab" href="#disapprovedF">Disapproved</a>
    	                            </li>
                                </ul>
                                <div>
                                    <div class="tab-content">
    	                                <div id="approvedF" class="container tab-pane active"><br>
    		                                <div class="container">
	                                                <div class="row">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                              <tr>
                                                                <th>Comment</th>
                                                                <th>Date</th>
                                                                <th>Patient</th>
                                                                <th>Status</th>
                                                              </tr>
                                                            </thead>
                                                            <tbody>
                                                              <tr v-for="f in approvedFeedbacks">
                                                                <td>{{f.text}}</td>
                                                                <td>{{DateSplit(f.date)}}</td>
                                                                <td v-for="p in patients" v-if="parseInt(p.id) == parseInt(f.patientId)">{{p.name}} {{p.surname}}</td>
                                                                <td v-if="parseInt(f.patientId) == -1">Anonimous</td>
                                                                <td style="text-align:center"><button class="btnban form-control" v-on:click="Disapprove(f)">D I S A P P R O V E</button></td>  
                                                              </tr>
                                                            </tbody>
                                                         </table>
	                                                </div>
                                              </div>			     
		                                 </div>
		                                <div id="disapprovedF" class="container tab-pane fade"><br>
                                            <div class="container">
                                                <div class="row">
                                                    <table class="table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th>Comment</th>
                                                                <th>Date</th>
                                                                <th>Patient</th>
                                                                <th>Status</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr v-for="f in disapprovedFeedbacks">
                                                                <td>{{f.text}}</td>
                                                                <td>{{DateSplit(f.date)}}</td>
                                                                <td v-for="p in patients" v-if="parseInt(p.id)== parseInt(f.patientId)">{{p.name}} {{p.surname}}</td>
                                                                <td v-if="parseInt(f.patientId) == -1">Anonimous</td>
                                                                <td style="text-align:center"><button class="btnapprove form-control" v-on:click="Approve(f)">A P P R O V E</button></td>
                                                            </tr>
                                                         </tbody>
                                                     </table> 
                                                </div>
                                            </div>			
                                        </div>
                                    </div>
                                </div>
    
        <br></br>
        <br></br>
        <br></br>
        <br></br>

    </div>
    </div>
	`,
    methods: {
        DateSplit: function (date) {
            var dates = (date.split("T")[0]).split("-")
            return dates[2] + "." + dates[1] + "." + dates[0]
        },
        Approve: function (feedback) {
            axios
                .put('/feedback/approve', feedback)
                .then(response => {
                    this.Refresh();
                })
                .catch(error => {
                    alert(error)
                })
        },
        Disapprove: function (feedback) {
            axios
                .put('/feedback/approve', feedback)
                .then(response => {
                    this.Refresh();
                })
                .catch(error => {
                    alert(error)
                })
        },
        Refresh: function () {
            axios
                .get('/feedback/approved')
                .then(response => {
                    this.approvedFeedbacks = response.data
                })
                .catch(error => {
                    alert(error)
                })
            axios
                .get('/feedback/disapproved')
                .then(response => {
                    this.disapprovedFeedbacks = response.data
                })
                .catch(error => {
                    alert(error)
                })
        }
    }
});