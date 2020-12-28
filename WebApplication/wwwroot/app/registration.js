Vue.component("registration", {
	data: function () {
		return {
			doctorsList: [],
			patientDTO: {
				name: null,
				surname: null,
				id: null,
				dateOfBirth: null,
				contact: null,
				email: null,
				address: {
					street: null,
				},
				password: null,
				parentName: null,
				placeOfBirth: null,
				municipalityOfBirth: null,
				stateOfBirth: null,
				citizenship: null,
				nationality: null,
				profession: null,
				placeOfResidence: null,
				municipalityOfResidence: null,
				stateOfResidence: null,
				employmentStatus: null,
				maritalStatus: null,
				gender: null,
				healthInsuranceNumber: null,
				familyDiseases: null,
				personalDiseases: null,
				image: null,
				guest: false,
				emailConfirmed: false,
				chosenDoctor:null,
			},
		}
	},
	mounted() {
		axios
			.get('/registration/allPhysitians')
			.then(response => {
				this.doctorsList = response.data
			})
			.catch(error => {
				alert(error)
			})
	},
	template: `
    <div class="container">
        <br/><h2 class="text1">Registration</h2>
		<hr class="line">
		
		<table class="t">
			<colgroup>
                 <col style="width: 60%;">
                 <col style="width: 50%;">
            </colgroup>
			<tr>
				<td><label>Name</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.name"/></td><br/>
			<tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{nameValidation}}</td>
			</tr>
			<tr>
				<td><label>Surname</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.surname"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{surnameValidation}}</td>
			</tr>
			<tr>
				<td><label>Parent name</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.parentName"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{parentNameValidation}}</td>
			</tr>
			<tr>
				<td><label>Unique citizens identity number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input" v-model="patientDTO.id"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Date of birth</label><a class="star">*</a></td>
				<td><input type="date" class = "form-control input" v-model="patientDTO.dateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Place of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.placeOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Municipality of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.municipalityOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>State of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.stateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Nationality</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.nationality"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Citizenship</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.citizenship"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Address</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.address.street"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Place of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.placeOfResidence"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Municipality of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.municipalityOfResidence"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>State of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.stateOfResidence"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
		
			</table>
			<table class="t">
			<tr>
				<td><label>Profesion</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.profession"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Employment status</label><a class="star">*</a></td>
				<td><select  class="combo form-control input" v-model="patientDTO.employmentStatus">
					<option>Employed</option>
					<option>Unemployed</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Marital status</label><a class="star">*</a></td>
				<td><select class="combo form-control input" v-model="patientDTO.maritalStatus">
					<option>Married</option>
					<option>Mot married</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Contact number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input" v-model="patientDTO.contact"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Email</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.email"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{mailValidation}}</td>
			</tr>
			<tr>
				<td><label>Password</label><a class="star">*</a></td>
				<td><input type="password" class = "form-control input"  v-model="patientDTO.password"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
			</td>
			<tr>
				<td><label>Gender</label><a class="star">*</a></td>
				<td><select class="combo form-control input" v-model="patientDTO.gender">
					<option>Male</option>
					<option>Female</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Health insurance number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input"  v-model="patientDTO.healthInsuranceNumber"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Family diseases</label></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.familyDiseases"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Personal diseases</label></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.personalDiseases"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Chosen doctor</label></td>
				<td><select class="combo form-control input" v-model = "patientDTO.chosenDoctor">
                     <option div  v-for="doctor in doctorsList" v-bind:value="doctor.serialNumber">{{doctor.name}} {{doctor.surname}}</option>
                </select></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
                 <td></td>
                <td align="left"><input type="file" accept="image/*" @change=uploadImage></td>

               </tr>
                <td align="left">Image:</td>
                <td><img  :src = "patientDTO.image" class = "form-control inputImage" style = "display:flex" width="100" heigh="50" /></td>
                <tr>
            </tr>
			</table>
			<button  type="button" class="btn2 btn-info btn-lg margin1" data-toggle="modal" data-target="#registrationInfo" v-on:click="AddPatient(patientDTO)" >Submit</button>
			<br/>
			<br/>
    </div>
	`,
	computed : {
		nameValidation: function () {
			if (this.patientDTO.name != undefined && this.patientDTO.name.length > 0) {
				let nameMatch = this.patientDTO.name.match('[A-Za-z ]*');
				if (nameMatch != this.patientDTO.name) return 'The name may contain only letters';
				else if (this.patientDTO.name[0].match('[A-Z]') === null) return 'The name must begin with a capital letter';
			}
			else if (this.patientDTO.name === '') return 'Name is a required field';
			else return null;
		},
		surnameValidation: function () {
			if (this.patientDTO.surname != undefined && this.patientDTO.surname.length > 0) {
				let surnameMatch = this.patientDTO.surname.match('[A-Za-z ]*');
				if (surnameMatch != this.patientDTO.surname) return 'The surname may contain only letters';
				else if (this.patientDTO.surname[0].match('[A-Z]') === null) return 'The surname must begin with a capital letter';
			}
			else if (this.patientDTO.surname === '') return 'Surname is a required field';
			else return null;
		},
		parentNameValidation: function () {
			if (this.patientDTO.parentName != undefined && this.patientDTO.parentName.length > 0) {
				let parentNameMatch = this.patientDTO.parentName.match('[A-Za-z ]*');
				if (parentNameMatch != this.patientDTO.parentName) return 'The parent name may contain only letters';
				else if (this.patientDTO.parentName[0].match('[A-Z]') === null) return 'The parent name must begin with a capital letter';
			}
			else if (this.patientDTO.parentName === '') return 'Parent name is a required field';
			else return null;
		},
		mailValidation: function () {
			if (this.patientDTO.email != undefined && this.patientDTO.email.length > 0) {
				let mailMatch = this.patientDTO.email.match("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
				if (mailMatch != this.patientDTO.email) return 'Not a good form of mail';
			}
			else if (this.patientDTO.email === '') return 'Mail name is a required field';
			else return null;
		},
    },
	methods: {
		uploadImage(e) {
			const previewImage = e.target.files[0];
			const reader = new FileReader();
			reader.readAsDataURL(previewImage);
			reader.onload = e => {
				this.patientDTO.image = e.target.result;
			};
		},
		AddPatient: function (patientDTO) {
			alert(this.patientDTO.chosenDoctor)
			if (patientDTO.name != null && patientDTO.surname != null && patientDTO.parentName != null && patientDTO.id != null
				&& patientDTO.dateOfBirth != null && patientDTO.placeOfBirth != null && patientDTO.municipalityOfBirth != null && patientDTO.stateOfBirth != null
				&& patientDTO.nationality != null && patientDTO.citizenship != null && patientDTO.address != null && patientDTO.placeOfResidence != null
				&& patientDTO.municipalityOfResidence != null && patientDTO.stateOfResidence != null && patientDTO.profession != null && patientDTO.employmentStatus != null
				&& patientDTO.maritalStatus != null && patientDTO.contact != null && patientDTO.email != null && patientDTO.password != null
				&& patientDTO.gender != null && patientDTO.healthInsuranceNumber != null) {
				axios
					.post("/registration/registerPatient", patientDTO)
					.then(response => {
						alert("Mail has been sent.");
					})

					.catch(error => {
						
						alert("Person with that unique citizens identity number already already exists.");
					})
			}
			else {
				alert("All fields are required.");

			}
		},
	},
});