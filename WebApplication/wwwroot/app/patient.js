Vue.component("patient", {
	data: function () {
		return {
			approvedFeedbacks: null,
			noapprovedFeedbacks: null,
			patients: null,
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				patientId: "TODO"
			}
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
			.get('http://localhost:49900/patient/all')
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
				alert(error)
			})
	},
	template: `
<div>
        <div>


		<div class="modal fade" tabindex="-1" role="dialog" id="feedbackModal">
			<div class="modal-dialog" role="document">
				<div class="modal-content">
					<div class="modal-header" id="feedbackModalHeader">
						<h5 class="modal-title">Ostavite recenziju</h5>
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body" id="feedbackModalBody">

						<label>Enter your comment here:</label>
						<input type="text" class="form-control" v-model="feedback.text">

					</div>
					<div class="modal-footer" id="feedbackModalFooter">
						<button type="button" class="btn btn-info btn-lg " v-on:click="addNewFeedback(feedback)">Pošalji</button>
						<button type="button" class="btn btn-info btn-lg " data-dismiss="modal">Odustani</button>
					</div>
				</div>
			</div>
		</div>  
    </div>
	
    <div class="container">
    <br/><h3 class="text">KOMENTARI
	<button type="button" class="btn btn-info btn-lg margin" data-toggle="modal" data-target="#feedbackModal">Open Modal</button>
	</h3>
	<br/>    
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
                             </table>
	                    </div>
                  </div>			
	    </div>
    </div>
   </div>
</div>
</div>
\
	`,
	methods: {
		addNewFeedback: function (feedback) {
			if (feedback.text != null) {
				axios
					.post("http://localhost:49900/feedback/add", feedback)
					.then(response => {``
						this.feedback.text = null;
						$('#feedbackModal').modal('hide')
					})
			}
			else
				alert("Morate uneti tekst recenzije.");

		},
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		}
	}

});