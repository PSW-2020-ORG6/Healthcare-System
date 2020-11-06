Vue.component("admin", {
    data: function () {
        return {
            approvedFeedbacks: null,
            noapprovedFeedbacks: null,
            feedback: null,
            patients: null
        }
    },
    beforeMount() {
        axios
            .get('http://localhost:49900/feedback/approved')
            .then(response => {
                this.approvedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })

        axios
            .get('http://localhost:49900/feedback/noapproved')
            .then(response => {
                this.noapprovedFeedbacks = response.data
            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('http://localhost:49900/patient/all')
            .then(response => {
                this.patients = response.data
            })
            .catch(error => {
                alert(error)
            })
    },
    template: `
<div class="container">
    <br/><h3 class="text">KOMENTARI</h3><br/>
	<ul class="nav nav-tabs" role="tablist">
    	<li class="nav-item">
    		<a class="nav-link active" data-toggle="tab" href="#profil">Odobreni</a>
    	</li>
    	<li class="nav-item">
    		<a class="nav-link" data-toggle="tab" href="#lozinka">Neodobreni</a>
    	</li>
    </ul>
    <div>
	    <div class="tab-content">
    	    <div id="profil" class="container tab-pane active"><br>
    		    <div class="container">
	                    <div class="row">
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th>Komentar</th>
                                    <th>Datum</th>
                                    <th colspan="2">Pacijent</th>
                                  </tr>
                                </thead>
                                <tbody>
                                  <tr v-for="f in approvedFeedbacks">
                                    <td>{{f.text}}</td>
                                    <td>{{DateSplit(f.date)}}</td>
                                    <td v-for="p in patients" v-if="p.id==f.patientId">{{p.name}} {{p.surname}}</td>
                                      
                                  </tr>
                                </tbody>
                             </table>
	                    </div>
                  </div>			     
		     </div>
		 <div id="lozinka" class="container tab-pane fade"><br>
		      <div class="container">
	                    <div class="row">
                            <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <th>Komentar</th>
                                    <th>Datum</th>
                                    <th colspan="2">Pacijent</th>

                                  </tr>
                                </thead>
                                <tbody>
                                  <tr v-for="f in noapprovedFeedbacks">
                                    <td>{{f.text}}</td>
                                    <td>{{f.date.getDate()}}</td>
                                    <td v-for="p in patients" v-if="p.id==f.patientId">{{p.name}} {{p.surname}}</td>
                                  </tr>
                                </tbody>
                             </table>
	                    </div>
                  </div>			
	    </div>
    </div>
 </div>
</div>
	`,
    methods: {
        DateSplit: function (date) {
            var dates = (date.split("T")[0]).split("-")
            return dates[2] + "." + dates[1] + "." + dates[0]
        }
    },
});