Vue.component("registration", {
	data: function () {
		return {
			patient: {
				name: null,
				surname: null,
				parentName: null,
				id: null,
				dateOfBirth: null,
				placeOfBirth: null,
				municipalityOfBirth: null,
				stateOfBirth: null,
				nationality: null,
				citizenship: null,
				address: null,
				placeOfResidence: null,
				municipalityOfResidence: null,
				stateOfResidence: null,
				profesion: null,
				employmentStatus: null,
				maritialStatus: null,
				contact: null,
				email: null,
				password: null,
				gender: null,
				helthInsuranceNumber: null,
				familyDiseases: null,
				personalDiseases: null,
				//image: null,
				//previewImage:null,
			},
		}
	},
    template: `
    <div class="container">
        <br/><h2 class="text1">Registration</h2>
		<hr class="line">
		
		<table class="t">
			<tr>
				<td><label>Name</label></td>
				<td><input type="text" v-model="patient.name"/></td><br/>
			<tr>
			<tr>
				<td><label>Surname</label></td>
				<td><input type="text" v-model="patient.surname"/></td><br/>
			</tr>
			<tr>
				<td><label>Parent name</label></td>
				<td><input type="text" v-model="patient.parentName"/></td><br/>
			</tr>
			<tr>
				<td><label>Unique citizens identity number</label></td>
				<td><input type="text" v-model="patient.id"/></td><br/>
			</tr>
			<tr>
				<td><label>Date of birth</label></td>
				<td><input type="date" v-model="patient.dateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td><label>Place of birth</label></td>
				<td><input type="text" v-model="patient.placeOfBirth"/></td><br/>
			</tr>
			<tr>
				<td><label>Municipality of birth</label></td>
				<td><input type="text" v-model="patient.municipalityOfBirth"/></td><br/>
			</tr>
			<tr>
				<td><label>State of birth</label></td>
				<td><input type="text" v-model="patient.stateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td><label>Nationality</label></td>
				<td><input type="text" v-model="patient.nationality"/></td><br/>
			</tr>
			<tr>
				<td><label>Citizenship</label></td>
				<td><input type="text" v-model="patient.citizenship"/></td><br/>
			</tr>
			<tr>
				<td><label>Address</label></td>
				<td><input type="text" v-model="patient.address"/></td><br/>
			</tr>
			<tr>
				<td><label>Place of residence</label></td>
				<td><input type="text" v-model="patient.placeOfResidence"/></td><br/>
			</tr>
			<tr>
				<td><label>Municipality of residence</label></td>
				<td><input type="text" v-model="patient.municipalityOfResidence"/></td><br/>
			</tr>
			<tr>
				<td><label>State of residence</label></td>
				<td><input type="text" v-model="patient.stateOfResidence"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
		
			</table>
			<table class="t">
			<tr>
				<td><label>Profesion</label></td>
				<td><input type="text" v-model="patient.profesion"/></td><br/>
			</tr>
			<tr>
				<td><label>Employment status</label></td>
				<td><select class="combo" v-model="patient.employmentStatus">
					<option value="volvo">Employed</option>
					<option value="saab">Unemployed</option>
				</select></td><br/>
			</tr>
			<tr>
				<td><label>Marital status</label></td>
				<td><select class="combo" v-model="patient.maritialStatus">
					<option value="">Married</option>
					<option value="">Mot married</option>
				</select></td><br/>
			</tr>
			<tr>
				<td><label>Contact number</label></td>
				<td><input type="text" v-model="patient.contact"/></td><br/>
			</tr>
			<tr>
				<td><label>Email</label></td>
				<td><input type="text" v-model="patient.email"/></td><br/>
			</tr>
			<tr>
				<td><label>Password</label></td>
				<td><input type="password" v-model="patient.password"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
			</td>
			<tr>
				<td><label>Gender</label></td>
				<td><select class="combo" v-model="patient.gender">
					<option value="">Male</option>
					<option value="">Female</option>
				</select></td><br/>
			</tr>
			<tr>
				<td><label>Helth insurance number</label></td>
				<td><input type="text" v-model="patient.helthInsuranceNumber"/></td><br/>
			</tr>
			<tr>
				<td><label>Family diseases</label></td>
				<td><input type="text" v-model="patient.familyDiseases"/></td><br/>
			</tr>
			<tr>
				<td><label>Personal diseases</label></td>
				<td><input type="text" v-model="patient.personalDiseases"/></td><br/>
			</tr>
			</table>
			<button type="button" class="btn2 btn-info btn-lg margin1" data-toggle="modal" data-target="#feedbackModal" v-on:click="AddPatient(patient)">Submit</button>
			<br/>
			<br/>
    </div>
	`,
	methods: {
		//uploadImage(e) {
		//	const image = e.target.files[0];
		//	const reader = new FileReader();
		//	reader.readAsDataURL(image);
		//	reader.onload = e => {
		//		this.previewImage = e.target.result;
		//	};
		//},
		//uploadImage(e) {
		//	const image = e.target.files[0];
		//	const reader = new FileReader();
		//	reader.readAsDataURL(image);
		//	reader.onload = e => {
		//		this.previewImage = e.target.result;
		//		console.log(this.previewImage);
		//	};
		//},
		AddPatient: function (patient) {
			alert(patient.dateOfBirth);
			//if (feedback.text != null || feedback.text != "") {
			axios
				.post("http://localhost:49900/registration/registerPatient", patient)
				.then(response => {

				})

				.catch(error => {
					alert("You need to enter a comment first.");
					//alert(this.response.data);
				})
		},
		/*else
			alert("You need to enter a comment first.");*/
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		}
	},
});