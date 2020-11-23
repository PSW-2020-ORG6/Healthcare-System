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
				image: null,
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
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{nameValidation}}</td>
			</tr>
			<tr>
				<td><label>Surname</label></td>
				<td><input type="text" v-model="patient.surname"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{surnameValidation}}</td>
			</tr>
			<tr>
				<td><label>Parent name</label></td>
				<td><input type="text" v-model="patient.parentName"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{parentNameValidation}}</td>
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
					<option selected="selected">Employed</option>
					<option>Unemployed</option>
				</select></td><br/>
			</tr>
			<tr>
				<td><label>Marital status</label></td>
				<td><select class="combo" v-model="patient.maritialStatus">
					<option>Married</option>
					<option>Mot married</option>
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
			<tr>
                             	<td></td>
                                <td align="left"><input type="file" accept="image/*" @change=uploadImage></td>

                            </tr>
                            <td align="left">Slika:</td>
                            <td><img  :src = "image" style = "display:flex" width="100" heigh="50" /></td>
                            <tr>
                            </tr>
			</table>
			<button type="button" class="btn2 btn-info btn-lg margin1" data-toggle="modal" data-target="#feedbackModal" v-on:click="AddPatient(patient)">Submit</button>
			<br/>
			<br/>
    </div>
	`,
	computed : {
		nameValidation: function () {
			if (this.patient.name != undefined && this.patient.name.length > 0) {
				let imeMatch = this.patient.name.match('[A-Za-z ]*');
				if (imeMatch != this.patient.name) return 'Ime u sebi moze sadrzati iskljucivo slova.';
				else if (this.patient.name[0].match('[A-Z]') === null) return 'Ime mora pocinjati velikim slovom.';
			}
			else if (this.name === '') return 'Ime je obavezno polje.';
			else return null;
		},
		surnameValidation: function () {
			if (this.patient.surname != undefined && this.patient.surname.length > 0) {
				let prezimeMatch = this.patient.surname.match('[A-Za-z ]*');
				if (prezimeMatch != this.patient.surname) return 'Prezimese u sebi moze sadrzati iskljucivo slova';
				else if (this.patient.surname[0].match('[A-Z]') === null) return 'Prezime mora pocinjati velikim slovom';
			}
			else if (this.surname === '') return 'Prezime je obavezno polje.';
			else return null;
		},
		parentNameValidation: function () {
			if (this.patient.parentName != undefined && this.patient.parentName.length > 0) {
				let prezimeMatch = this.patient.parentName.match('[A-Za-z ]*');
				if (prezimeMatch != this.patient.parentName) return 'Ime roditelja u sebi moze sadrzati iskljucivo slova';
				else if (this.patient.parentName[0].match('[A-Z]') === null) return 'Ime roditelja mora pocinjati velikim slovom';
			}
			else if (this.surname === '') return 'Prezime je obavezno polje.';
			else return null;
		},
    },
	methods: {
		uploadImage(e) {
			const previewImage = e.target.files[0];
			const reader = new FileReader();
			reader.readAsDataURL(previewImage);
			reader.onload = e => {
				this.patient.image = e.target.result;
			};
		},
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
			//alert(patient.image);
			if (patient.name != null && patient.surname != null && patient.parentName != null && patient.id != null
				&& patient.dateOfBirth != null && patient.placeOfBirth != null && municipalityOfBirth != null && patient.stateOfBirth != null
				&& patient.nationality != null && patient.citizenship != null && patient.address != null && patient.placeOfResidence != null
				&& patient.municipalityOfResidence != null && patient.stateOfResidence != null && patient.profesion != null && patient.employmentStatus != null
				&& patient.maritialStatus != null && patient.contact != null && patient.email != null && patient.password != null
				&& patient.gender != null && patient.helthInsuranceNumber != null && patient.familyDiseases != null && patient.personalDiseases != null) {
				axios
					.post("http://localhost:49900/registration/registerPatient", patient)
					.then(response => {

					})

					.catch(error => {
						alert("Person with that unique citizens identity number already already exists.");
					})
			}
			else {
				alert("All fields are required.");
			}
		},
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		}
	},
});