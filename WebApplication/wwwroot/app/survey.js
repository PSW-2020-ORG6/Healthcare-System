var doctorNameAppointment
Vue.component("survey", {
    data: function () {
        return {
            patient: {},
            doctorsList: [],
            // patientId: "12",
            dName: doctorNameAppointment,
            selectedDoctor: {},
            surveyText: {
                id: "96736fd7-3018-4f3f-a14b-35610a1c8959",
                questions:[],
                DoctorName: null,
                reportDate: null,
            }
        }
    },
    beforeMount() {
        axios
            .get('/survey/getDoctorsForSurveyList', { params: { patientId: this.surveyText.id } })
            .then(response => {
                this.doctorsList = response.data
            })
            .catch(error => {
                alert(error)
            })
    },
    template: `
    <div id = "entireSurvey">
        <div id="sText">
           <p id="textSurvey"><i>Dear patient,<br>
               At Health Clinic,we are commited to your healthcare.We are interested in knowing what do you thing abaut our services.
                You performance by completing this survey regarding your visit.<br>Thank you for taking time to share your expirience with us.<br><br>
               Please rate the following toppings on a scale of 1 to 5,with 1 being poor and 5 being exellent.</i>
            </p>
            <p id="textSurvey">Select doctor to rate:<br>
                <select id="doctorSelect" class="browser-default custom-select" v-model = "surveyText.DoctorName">
                     <option div v-if="dName==null" v-for="(doctor) in doctorsList" v-bind:value="doctor">{{doctor}}</option>
                    <option div v-if="dName!=null"  v-bind:value="dName">{{this.dName}}</option>
                </select>
            </p>            <div class="question" id="q">
              <b id="topic">Topic 1 Doctor</b>
                <p>1.The doctor is welcoming and gentle?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse" >
                        <input type="radio" id="star1RatingOne" name="ratingOne" value="5" v-model = "surveyText.questions[0]" /><label for="star1RatingOne" title="5 star"></label>
                        <input type="radio" id="star2RatingOne" name="ratingOne" value="4" v-model = "surveyText.questions[0]"/><label for="star2RatingOne" title="4 star"></label>
                        <input type="radio" id="star3RatingOne" name="ratingOne" value="3" v-model = "surveyText.questions[0]"/><label for="star3RatingOne" title="3 star"></label>
                        <input type="radio" id="star4RatingOne" name="ratingOne" value="2" v-model = "surveyText.questions[0]"/><label for="star4RatingOne" title="2 star"></label>
                        <input type="radio" id="star5RatingOne" name="ratingOne" value="1" v-model = "surveyText.questions[0]"/><label for="star5RatingOne" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>2.The doctor answered all of your questions in an understandable manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwo" name="ratingTwo" value="5" v-model = "surveyText.questions[1]"/><label for="star1RatingTwo" title="5 star"></label>
                        <input type="radio" id="star2RatingTwo" name="ratingTwo" value="4" v-model = "surveyText.questions[1]"/><label for="star2RatingTwo" title="4 star"></label>
                        <input type="radio" id="star3RatingTwo" name="ratingTwo" value="3" v-model = "surveyText.questions[1]"/><label for="star3RatingTwo" title="3 star"></label>
                        <input type="radio" id="star4RatingTwo" name="ratingTwo" value="2" v-model = "surveyText.questions[1]"/><label for="star4RatingTwo" title="2 star"></label>
                        <input type="radio" id="star5RatingTwo" name="ratingTwo" value="1" v-model = "surveyText.questions[1]"/><label for="star5RatingTwo" title="1 star"></label>
                    </div>
              </div>
             <div class="question" id="q">
                <p>3.The doctor takes care of you in a professional manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingThree" name="ratingThree" value="5" v-model = "surveyText.questions[2]"/><label for="star1RatingThree" title="5 star"></label>
                        <input type="radio" id="star2RatingThree" name="ratingThree" value="4" v-model = "surveyText.questions[2]"/><label for="star2RatingThree" title="4 star"></label>
                        <input type="radio" id="star3RatingThree" name="ratingThree" value="3" v-model = "surveyText.questions[2]"/><label for="star3RatingThree" title="3 star"></label>
                        <input type="radio" id="star4RatingThree" name="ratingThree" value="2" v-model = "surveyText.questions[2]"/><label for="star4RatingThree" title="2 star"></label>
                        <input type="radio" id="star5RatingThree" name="ratingThree" value="1" v-model = "surveyText.questions[2]"/><label for="star5RatingThree" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
                <p>4.Would you have the procedure done again by this doctor?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFour" name="ratingFour" value="5" v-model = "surveyText.questions[3]"/><label for="star1RatingFour" title="5 star"></label>
                        <input type="radio" id="star2RatingFour" name="ratingFour" value="4" v-model = "surveyText.questions[3]"/><label for="star2RatingFour" title="4 star"></label>
                        <input type="radio" id="star3RatingFour" name="ratingFour" value="3" v-model = "surveyText.questions[3]"/><label for="star3RatingFour" title="3 star"></label>
                        <input type="radio" id="star4RatingFour" name="ratingFour" value="2" v-model = "surveyText.questions[3]"/><label for="star4RatingFour" title="2 star"></label>
                        <input type="radio" id="star5RatingFour" name="ratingFour" value="1" v-model = "surveyText.questions[3]"/><label for="star5RatingFour" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
              <b id="topic">Topic 2 Nurse's care</b>
                <p>5.The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFive" name="ratingFive" value="5" v-model = "surveyText.questions[4]"/><label for="star1RatingFive" title="5 star"></label>
                        <input type="radio" id="star2RatingFive" name="ratingFive" value="4" v-model = "surveyText.questions[4]"/><label for="star2RatingFive" title="4 star"></label>
                        <input type="radio" id="star3RatingFive" name="ratingFive" value="3" v-model = "surveyText.questions[4]"/><label for="star3RatingFive" title="3 star"></label>
                        <input type="radio" id="star4RatingFive" name="ratingFive" value="2" v-model = "surveyText.questions[4]"/><label for="star4RatingFive" title="2 star"></label>
                        <input type="radio" id="star5RatingFive" name="ratingFive" value="1" v-model = "surveyText.questions[4]"/><label for="star5RatingFive" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>6.The nursees answered all of your questions in an understandable manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSix" name="ratingSix" value="5" v-model = "surveyText.questions[5]"/><label for="star1RatingSix" title="5 star"></label>
                        <input type="radio" id="star2RatingSix" name="ratingSix" value="4" v-model = "surveyText.questions[5]"/><label for="star2RatingSix" title="4 star"></label>
                        <input type="radio" id="star3RatingSix" name="ratingSix" value="3" v-model = "surveyText.questions[5]"/><label for="star3RatingSix" title="3 star"></label>
                        <input type="radio" id="star4RatingSix" name="ratingSix" value="2" v-model = "surveyText.questions[5]"/><label for="star4RatingSix" title="2 star"></label>
                        <input type="radio" id="star5RatingSix" name="ratingSix" value="1" v-model = "surveyText.questions[5]"/><label for="star5RatingSix" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>7.Orientation given to warn setup</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSeven" name="ratingSeven" value="5" v-model = "surveyText.questions[6]"/><label for="star1RatingSeven" title="5 star"></label>
                        <input type="radio" id="star2RatingSeven" name="ratingSeven" value="4" v-model = "surveyText.questions[6]"/><label for="star2RatingSeven" title="4 star"></label>
                        <input type="radio" id="star3RatingSeven" name="ratingSeven" value="3" v-model = "surveyText.questions[6]"/><label for="star3RatingSeven" title="3 star"></label>
                        <input type="radio" id="star4RatingSeven" name="ratingSeven" value="2" v-model = "surveyText.questions[6]"/><label for="star4RatingSeven" title="2 star"></label>
                        <input type="radio" id="star5RatingSeven" name="ratingSeven" value="1" v-model = "surveyText.questions[6]"/><label for="star5RatingSeven" title="1 star"></label>
                    </div>
              </div>
             <div class="question" id="q">
                <p>8.The nurse gave you good discharge instructions</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEight" name="ratingEight" value="5" v-model = "surveyText.questions[7]"/><label for="star1RatingEight" title="5 star"></label>
                        <input type="radio" id="star2RatingEight" name="ratingEight" value="4" v-model = "surveyText.questions[7]"/><label for="star2RatingEight" title="4 star"></label>
                        <input type="radio" id="star3RatingEight" name="ratingEight" value="3" v-model = "surveyText.questions[7]"/><label for="star3RatingEight" title="3 star"></label>
                        <input type="radio" id="star4RatingEight" name="ratingEight" value="2" v-model = "surveyText.questions[7]"/><label for="star4RatingEight" title="2 star"></label>
                        <input type="radio" id="star5RatingEight" name="ratingEight" value="1" v-model = "surveyText.questions[7]"/><label for="star5RatingEight" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
                <p>9.The nurse was concerned for you?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingNine" name="ratingNine" value="5" v-model = "surveyText.questions[8]"/><label for="star1RatingNine" title="5 star"></label>
                        <input type="radio" id="star2RatingNine" name="ratingNine" value="4" v-model = "surveyText.questions[8]"/><label for="star2RatingNine" title="4 star"></label>
                        <input type="radio" id="star3RatingNine" name="ratingNine" value="3" v-model = "surveyText.questions[8]"/><label for="star3RatingNine" title="3 star"></label>
                        <input type="radio" id="star4RatingNine" name="ratingNine" value="2" v-model = "surveyText.questions[8]"/><label for="star4RatingNine" title="2 star"></label>
                        <input type="radio" id="star5RatingNine" name="ratingNine" value="1" v-model = "surveyText.questions[8]"/><label for="star5RatingNine" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
              <b id="topic">Topic 3 Clinic's hygiene and ambience</b>
                <p>10.The comfort and cleanliness of the facility </p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTen" name="ratingTen" value="5" v-model = "surveyText.questions[9]"/><label for="star1RatingTen" title="5 star"></label>
                        <input type="radio" id="star2RatingTen" name="ratingTen" value="4" v-model = "surveyText.questions[9]"/><label for="star2RatingTen" title="4 star"></label>
                        <input type="radio" id="star3RatingTen" name="ratingTen" value="3" v-model = "surveyText.questions[9]"/><label for="star3RatingTen" title="3 star"></label>
                        <input type="radio" id="star4RatingTen" name="ratingTen" value="2" v-model = "surveyText.questions[9]"/><label for="star4RatingTen" title="2 star"></label>
                        <input type="radio" id="star5RatingTen" name="ratingTen" value="1" v-model = "surveyText.questions[9]"/><label for="star5RatingTen" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>11.Comfort level within the procedure room?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEleven" name="ratingEleven" value="5" v-model = "surveyText.questions[10]"/><label for="star1RatingEleven" title="5 star"></label>
                        <input type="radio" id="star2RatingEleven" name="ratingEleven" value="4" v-model = "surveyText.questions[10]"/><label for="star2RatingEleven" title="4 star"></label>
                        <input type="radio" id="star3RatingEleven" name="ratingEleven" value="3" v-model = "surveyText.questions[10]"/><label for="star3RatingEleven" title="3 star"></label>
                        <input type="radio" id="star4RatingEleven" name="ratingEleven" value="2" v-model = "surveyText.questions[10]"/><label for="star4RatingEleven" title="2 star"></label>
                        <input type="radio" id="star5RatingEleven" name="ratingEleven" value="1" v-model = "surveyText.questions[10]"/><label for="star5RatingEleven" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>12.Conditions of the rooms(temperature,comfort,silence)</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwelve" name="ratingTwelve" value="5" v-model = "surveyText.questions[11]"/><label for="star1RatingTwelve" title="5 star"></label>
                        <input type="radio" id="star2RatingTwelve" name="ratingTwelve" value="4" v-model = "surveyText.questions[11]"/><label for="star2RatingTwelve" title="4 star"></label>
                        <input type="radio" id="star3RatingTwelve" name="ratingTwelve" value="3" v-model = "surveyText.questions[11]"/><label for="star3RatingTwelve" title="3 star"></label>
                        <input type="radio" id="star4RatingTwelve" name="ratingTwelve" value="2" v-model = "surveyText.questions[11]"/><label for="star4RatingTwelve" title="2 star"></label>
                        <input type="radio" id="star5RatingTwelve" name="ratingTwelve" value="1" v-model = "surveyText.questions[11]"/><label for="star5RatingTwelve" title="1 star"></label>
                    </div>
              </div>
             <div class="question" id="q">
                <p>13.General impression of the ambient atmosphere</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingThirteen" name="ratingThirteen" value="5" v-model = "surveyText.questions[12]"/><label for="star1RatingThirteen" title="5 star"></label>
                        <input type="radio" id="star2RatingThirteen" name="ratingThirteen" value="4" v-model = "surveyText.questions[12]"/><label for="star2RatingThirteen" title="4 star"></label>
                        <input type="radio" id="star3RatingThirteen" name="ratingThirteen" value="3" v-model = "surveyText.questions[12]"/><label for="star3RatingThirteen" title="3 star"></label>
                        <input type="radio" id="star4RatingThirteen" name="ratingThirteen" value="2" v-model = "surveyText.questions[12]"/><label for="star4RatingThirteen" title="2 star"></label>
                        <input type="radio" id="star5RatingThirteen" name="ratingThirteen" value="1" v-model = "surveyText.questions[12]"/><label for="star5RatingThirteen" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
              <b id="topic">Topic 4 Clinic's pharmacy supplies and equipment </b>
                <p>14.Do you think the clinic has the necessary equipment</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFourteen" name="ratingFourteen" value="5" v-model = "surveyText.questions[13]"/><label for="star1RatingFourteen" title="5 star"></label>
                        <input type="radio" id="star2RatingFourteen" name="ratingFourteen" value="4" v-model = "surveyText.questions[13]"/><label for="star2RatingFourteen" title="4 star"></label>
                        <input type="radio" id="star3RatingFourteen" name="ratingFourteen" value="3" v-model = "surveyText.questions[13]"/><label for="star3RatingFourteen" title="3 star"></label>
                        <input type="radio" id="star4RatingFourteen" name="ratingFourteen" value="2" v-model = "surveyText.questions[13]"/><label for="star4RatingFourteen" title="2 star"></label>
                        <input type="radio" id="star5RatingFourteen" name="ratingFourteen" value="1" v-model = "surveyText.questions[13]"/><label for="star5RatingFourteen" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>15.Do you think the clinic's farmacy has the necessary drugs?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFifteen" name="ratingFifteen" value="5" v-model = "surveyText.questions[14]"/><label for="star1RatingFifteen" title="5 star"></label>
                        <input type="radio" id="star2RatingFifteen" name="ratingFifteen" value="4" v-model = "surveyText.questions[14]"/><label for="star2RatingFifteen" title="4 star"></label>
                        <input type="radio" id="star3RatingFifteen" name="ratingFifteen" value="3" v-model = "surveyText.questions[14]"/><label for="star3RatingFifteen" title="3 star"></label>
                        <input type="radio" id="star4RatingFifteen" name="ratingFifteen" value="2" v-model = "surveyText.questions[14]"/><label for="star4RatingFifteen" title="2 star"></label>
                        <input type="radio" id="star5RatingFifteen" name="ratingFifteen" value="1" v-model = "surveyText.questions[14]"/><label for="star5RatingFifteen" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>16.Do you think that the hospital should have more modern equipment than the current one</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSixteen" name="ratingSixteen" value="5" v-model = "surveyText.questions[15]"/><label for="star1RatingSixteen" title="5 star"></label>
                        <input type="radio" id="star2RatingSixteen" name="ratingSixteen" value="4" v-model = "surveyText.questions[15]"/><label for="star2RatingSixteen" title="4 star"></label>
                        <input type="radio" id="star3RatingSixteen" name="ratingSixteen" value="3" v-model = "surveyText.questions[15]"/><label for="star3RatingSixteen" title="3 star"></label>
                        <input type="radio" id="star4RatingSixteen" name="ratingSixteen" value="2" v-model = "surveyText.questions[15]"/><label for="star4RatingSixteen" title="2 star"></label>
                        <input type="radio" id="star5RatingSixteen" name="ratingSixteen" value="1" v-model = "surveyText.questions[15]"/><label for="star5RatingSixteen" title="1 star"></label>
                    </div>
              </div>
             <div class="question" id="q">
                <p>17.Did you noticed broken or damaged equipment in the hospital</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSeventeen" name="ratingSeventeen" value="5" v-model = "surveyText.questions[16]"/><label for="star1RatingSeventeen" title="5 star"></label>
                        <input type="radio" id="star2RatingSeventeen" name="ratingSeventeen" value="4" v-model = "surveyText.questions[16]"/><label for="star2RatingSeventeen" title="4 star"></label>
                        <input type="radio" id="star3RatingSeventeen" name="ratingSeventeen" value="3" v-model = "surveyText.questions[16]"/><label for="star3RatingSeventeen" title="3 star"></label>
                        <input type="radio" id="star4RatingSeventeen" name="ratingSeventeen" value="2" v-model = "surveyText.questions[16]"/><label for="star4RatingSeventeen" title="2 star"></label>
                        <input type="radio" id="star5RatingSeventeen" name="ratingSeventeen" value="1" v-model = "surveyText.questions[16]"/><label for="star5RatingSeventeen" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
                <p>18.The doctor prescribed medications that I could buy at the clinic's pharmacy</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEighteen" name="ratingEighteen" value="5" v-model="surveyText.questions[17]"/><label for="star1RatingEighteen" title="5 star"></label>
                        <input type="radio" id="star2RatingEighteen" name="ratingEighteen" value="4" v-model="surveyText.questions[17]"/><label for="star2RatingEighteen" title="4 star"></label>
                        <input type="radio" id="star3RatingEighteen" name="ratingEighteen" value="3" v-model="surveyText.questions[17]"/><label for="star3RatingEighteen" title="3 star"></label>
                        <input type="radio" id="star4RatingEighteen" name="ratingEighteen" value="2" v-model="surveyText.questions[17]"/><label for="star4RatingEighteen" title="2 star"></label>
                        <input type="radio" id="star5RatingEighteen" name="ratingEighteen" value="1" v-model="surveyText.questions[17]"/><label for="star5RatingEighteen" title="1 star"></label>
                    </div>
              </div>
           <div class="question" id="q">
              <b id="topic">Topic 5 Website </b>
                <p>19.Did you found it easy to use our website</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingNineteen" name="ratingNineteen" value="5" v-model="surveyText.questions[18]" /><label for="star1RatingNineteen" title="5 star"></label>
                        <input type="radio" id="star2RatingNineteen" name="ratingNineteen" value="4" v-model="surveyText.questions[18]" /><label for="star2RatingNineteen" title="4 star"></label>
                        <input type="radio" id="star3RatingNineteen" name="ratingNineteen" value="3" v-model="surveyText.questions[18]"/><label for="star3RatingNineteen" title="3 star"></label>
                        <input type="radio" id="star4RatingNineteen" name="ratingNineteen" value="2" v-model="surveyText.questions[18]"/><label for="star4RatingNineteen" title="2 star"></label>
                        <input type="radio" id="star5RatingNineteen" name="ratingNineteen" value="1" v-model="surveyText.questions[18]"/><label for="star5RatingNineteen" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <p>20.Did you have found all the necessary information on our website?</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwenty" name="ratingTwenty" value="5" v-model="surveyText.questions[19]"/><label for="star1RatingTwenty" title="5 star"></label>
                        <input type="radio" id="star2RatingTwenty" name="ratingTwenty" value="4" v-model="surveyText.questions[19]"/><label for="star2RatingTwenty" title="4 star"></label>
                        <input type="radio" id="star3RatingTwenty" name="ratingTwenty" value="3" v-model="surveyText.questions[19]"/><label for="star3RatingTwenty" title="3 star"></label>
                        <input type="radio" id="star4RatingTwenty" name="ratingTwenty" value="2" v-model="surveyText.questions[19]"/><label for="star4RatingTwenty" title="2 star"></label>
                        <input type="radio" id="star5RatingTwenty" name="ratingTwenty" value="1" v-model="surveyText.questions[19]"/><label for="star5RatingTwenty" title="1 star"></label>
                    </div>
              </div>
              <div class="question" id="q">
                <b id="topic">Topic 6 General opinion </b>
                <p>21.Overall, are you satisfied with the care you received in this facility?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyOne" name="ratingTwentyOne" value="5" v-model="surveyText.questions[20]"/><label for="star1RatingTwentyOne" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyOne" name="ratingTwentyOne" value="4" v-model="surveyText.questions[20]"/><label for="star2RatingTwentyOne" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyOne" name="ratingTwentyOne" value="3" v-model="surveyText.questions[20]"/><label for="star3RatingTwentyOne" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyOne" name="ratingTwentyOne" value="2" v-model="surveyText.questions[20]"/><label for="star4RatingTwentyOne" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyOne" name="ratingTwentyOne" value="1" v-model="surveyText.questions[20]"/><label for="star5RatingTwentyOne" title="1 star"></label>
                    </div>
              </div>
             <div class="question" id="q">
                <p>22.Would you come to this institution again</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyTwo" name="ratingTwentyTwo" value="5" v-model="surveyText.questions[21]"/><label for="star1RatingTwentyTwo" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyTwo" name="ratingTwentyTwo" value="4" v-model="surveyText.questions[21]"/><label for="star2RatingTwentyTwo" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyTwo" name="ratingTwentyTwo" value="3" v-model="surveyText.questions[21]"/><label for="star3RatingTwentyTwo" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyTwo" name="ratingTwentyTwo" value="2" v-model="surveyText.questions[21]"/><label for="star4RatingTwentyTwo" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyTwo" name="ratingTwentyTwo" value="1" v-model="surveyText.questions[21]"/><label for="star5RatingTwentyTwo" title="1 star"></label>
                    </div>
              </div>
            <div class="question" id="q">
                <p>23.Would you recommend this facility to your friends and family</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyThree" name="ratingTwentyThree" value="5" v-model="surveyText.questions[22]" /><label for="star1RatingTwentyThree" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyThree" name="ratingTwentyThree" value="4" v-model="surveyText.questions[22]"/><label for="star2RatingTwentyThree" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyThree" name="ratingTwentyThree" value="3" v-model="surveyText.questions[22]"/><label for="star3RatingTwentyThree" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyThree" name="ratingTwentyThree" value="2" v-model="surveyText.questions[22]"/><label for="star4RatingTwentyThree" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyThree" name="ratingTwentyThree" value="1" v-model="surveyText.questions[22]"/><label for="star5RatingTwentyThree" title="1 star"></label>
                    </div>
              </div>
			  <button type="button" class="btn btn-info btn-lg buttonBottom " data-toggle="modal"  v-on:click="AddNewSurvey()">Send</button>
                    <div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
                          <!-- Modal content-->
                          <div class="modal-content">
                            <div class="modal-header">
                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                              <p>Please choose a doctor who is a subject of this survey.</p>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
                            </div>
                          </div>
                        </div>
                      </div>
                       <div class="modal fade" id="myModal1" role="dialog">
                        <div class="modal-dialog">
                          <!-- Modal content-->
                          <div class="modal-content">
                            <div class="modal-header">
                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                              <p>Please answer all questions.</p>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                            </div>
                          </div>
                        </div>
                      </div>

                      <div class="modal fade" id="myModal5" role="dialog">
                        <div class="modal-dialog">
                          <!-- Modal content-->
                          <div class="modal-content">
                            <div class="modal-header">
                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                              <p>Successfully added survey.</p>
                            </div>
                            <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" v-on:click="PatientShow()" >Ok</button>
                            </div>
                          </div>
                        </div>
                      </div>

              <button type="button" class="btn btn-info btn-lg buttonBottom " data-dismiss="modal" v-on:click="PatientShow()" >Cancel</button>
        </div>
    </div>
	`,
    methods: {

        PatientShow: function () {
            this.$router.push('patient');
        },
        AddNewSurvey: function (surveyText) {
            if (!document.getElementById("star1RatingTwentyThree").checked && !document.getElementById("star1RatingTwentyTwo").checked &&
                !document.getElementById("star1RatingTwentyOne").checked && !document.getElementById("star1RatingTwenty").checked &&
                !document.getElementById("star2RatingNineteen").checked && !document.getElementById("star3RatingEighteen").checked &&
                !document.getElementById("star1RatingSeventeen").checked && !document.getElementById("star1RatingSixteen").checked &&
                !document.getElementById("star2RatingFifteen").checked && !document.getElementById("star1RatingFourteen").checked &&
                !document.getElementById("star2RatingThirteen").checked && !document.getElementById("star4RatingTwelve").checked &&
                !document.getElementById("star3RatingEleven").checked && !document.getElementById("star4RatingTen").checked &&
                !document.getElementById("star2RatingNine").checked && !document.getElementById("star4RatingEight").checked &&
                !document.getElementById("star2RatingSeven").checked && !document.getElementById("star4RatingSix").checked &&
                !document.getElementById("star2RatingFive").checked && !document.getElementById("star4RatingFour").checked &&
                !document.getElementById("star2RatingThree").checked && !document.getElementById("star4RatingTwo").checked &&
                !document.getElementById("star4RatingOne").checked) {

                $('#myModal1').modal('show');


                return
            }
            selectedValue = $('#doctorSelect').val()
            if (selectedValue == null) {
                $('#myModal').modal('show')
                return
            }

            var surveyText = this.surveyText
            var textSptlit = $('#doctorSelect').val()

            var parts = textSptlit.split("-")
            var doctorName = parts[0]
            var dDate = parts[1].split(".")
            dDateVar = dDate[2] + "," + dDate[1] + "," + dDate[0]
            var dateSurvey = new Date("'" + dDateVar + "'")


            this.surveyText.DoctorName = doctorName
            this.surveyText.reportDate = dateSurvey;


            axios
                .post('/survey/add', surveyText)
                .then(response => {
                })
            $('#myModal5').modal('show');
        }
    }
});

Vue.component("appointments", {
    data: function () {
        return {
            appointmentDto: null,
            idPatient: "96736fd7-3018-4f3f-a14b-35610a1c8959",
            isSurveyDone: null,
            activeAppointments: null,
            canceledAppointments: null,
            appointmentsWithSurvey: null,
            appointmentsWithoutSurvey: null,
            pastAppointments: null,
            patients: null,
            doctorsList: null,
            appointment: null,
            patientDTO: {},
            isMalicious: {},

            physicians: null,
            specializations: null,
            choosenSpecialization: null,
            choosenPhysician: null,
            date: null,
            physicianForChoose: [],
            id: 1,
            timeIntervals: null,
            timeInterval: null,
            display: false,
            appointmentDto: null,
            informations: null,
            display1: false,
            myDate: null
        }
    },
    beforeMount() {
        axios
            .get('/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.activeAppointments = response.data
            })

            .catch(error => {
                alert(error.value)
            })

        axios
            .get('/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.canceledAppointments = response.data

            })
            .catch(error => {
                alert(error.value)
            })

        axios
            .get('/appointment/allAppointmentsByPatientIdPast', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.pastAppointments = response.data

            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('/appointment/allAppointmentsWithSurvey', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.appointmentsWithSurvey = response.data

            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('/appointment/allAppointmentsWithoutSurvey', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.appointmentsWithoutSurvey = response.data

            })
            .catch(error => {
                alert(error)
            })


        axios
            .get('/survey/getDoctorsForSurveyList', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
            .then(response => {
                this.doctorsList = response.data
            })
            .catch(error => {
                alert(error)
            })
        axios
            .get('/appointment/physicians')
            .then(response => {
                this.physicians = response.data
            })
        axios
            .get('/appointment/specializations')
            .then(response => {
                this.specializations = response.data
            })
    },
    template: `
	<div id="appointments">
        </br>
            <div class="row create" >
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createAppointment">Create new appointment</button>&nbsp&nbsp&nbsp&nbsp
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createAppointmentRecommendation">Create new appointment with recommendation</button>&nbsp&nbsp&nbsp&nbsp
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createAppointmentMyChoosenDoctor">Create new appointment with my choosen doctor</button>
            </div>
            </br>
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
          <div class="modal fade" id="createAppointmentRecommendation" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
              <div class="modal-dialog modal-dialog-centered" role="document" style="width:900px;height:500px">
                    <div class="modal-content steps">
                        <div class="container" align="center">
                            <br/><h4 class="text">Create new appointment</h4><br/></br>
                        </div>  
                        <div class="tab-content">
                        <div id="parameters" align="center" v-if="!display">
                            <label>Choose date span:</label></br>
                                <div class="row">
                                    <label>&nbsp&nbsp&nbsp Date from &nbsp</label><input id="dateFrom" type="date"></input>
                                    <label>&nbsp to &nbsp</label><input id="dateTo" type="date"></input>
                                 </div></br>
                                 <label id="validationDates" class="correct" style="color:red">You must select a dates!</label></br> 
                                 <label>Choose  specialization:</label></br>
                                 <select id="selectSpecialization" class="select" v-model="choosenSpecialization" v-on:change="SpecialistForChoose()">
                                        <option disabled>Please select one</option>
                                        <option v-for="s in specializations">{{s.name}}</option>
                                    </select></br>
                                 <label id="validationSpecialization" class="correct" style="color:red">You must select a specialization!</label></br>
                                 </br></br>
                                 <label>Choose physician:</label></br>
                                 <select id="selectPhysician" class="select" v-model="choosenPhysician">
                                         <option disabled selected="selected">Please select one</option>
                                         <option v-for="p in physicianForChoose" v-bind:value="p">{{p.fullName}}</option>
                                  </select></br>
                                 <label id="validationPhysician" class="correct" style="color:red">You must select a physician!</label></br>
                                 </br></br>
                                 <label>Select the primary parameter:</label></br>
                                 <input id="cbp" type="checkbox" value="physician" v-on:click="Checkbox('cbp')"/>
                                 <label>physician</label>&nbsp&nbsp&nbsp
                                 <input id="cbd" type="checkbox" value="date" v-on:click="Checkbox('cbd')"/>
                                 <label>date</label></br>
                                 <label id="validationParameter" class="correct" style="color:red">You must select a parameter!</label></br>
                                 </br></br>
		                         <button type="button" class="btn btn-primary" v-on:click="DisplayAppointments()">Display appointments</button>
                                 </br></br>
                            </div> 
                            <div  v-if="display">
                                <label>Choose  time:</label></br>
                                    <select class="select" v-model="informations">
                                       <template v-for="a in appointmentDto">
                                        <option  v-for="t in a.timeIntervals" v-bind:value="[a, t]">{{t.time}} &nbsp&nbsp {{a.date}}  &nbsp&nbsp {{a.physicianFullName}}</option>
                                       </template>
                                    </select>
                                    </br></br></br></br>
                                    <button class="btn btnNext" v-on:click="MakeAppointment2()">Submit</button>
                                    </br></br>
                            </div>
                        </div>
                    </div>
                  </div>
                </div>
             <div class="modal fade" id="createAppointmentMyChoosenDoctor" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
              <div class="modal-dialog modal-dialog-centered" role="document" style="width:900px;height:200px">
                    <div class="modal-content steps">
                        <div class="container" align="center">
                            <br/><h4 class="text">Create new appointment</h4><br/></br>
                        </div>
                        <div id="parameters" align="center" v-if="!display1">
                           
                                    <label>&nbsp&nbsp&nbsp Choose date &nbsp</label></br><input id="myDate" type="date"></input>
                                 </br></br>
                                 <button type="button" class="btn btn-primary" v-on:click="DisplayAppointmentsMyChoosenDoctor()">Display appointments</button>
                                 </br></br> 
                        </div>
                        <div  v-if="display1">
                                <label>Choose  time:</label></br>
                                    <select class="select" v-model ="timeInterval">
                                        <option div  v-for="t in timeIntervals" v-bind:value="t">{{t.time}}</option>
                                    </select>
                                    </br></br></br></br>
                                    <button class="btn btnNext" v-on:click="MakeAppointment3()">Submit</button>
                                    </br></br>
                           </div>
                     </div>
            </div>
          </div>
		<div class="container"><br/>
			
			<p>Active Appointments<p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="appointmentDto in activeAppointments">
											<td>{{DateSplit(appointmentDto.date)}}</td>
											<td>{{TimeSplit(appointmentDto.timeIntervalDTO.start)}}</td>
											<td>{{appointmentDto.physicianDTO.fullName}}</td>
											<td>{{appointmentDto.roomDTO.name}}</td>
											<td>{{appointmentDto.procedureTypeDTO.name}}</td>
											<td>{{appointmentDto.urgency}}</td>
											<td><button type="button" class="btn btn-info btn-lg" v-on:click="cancelAppointment(appointmentDto)">Cancel</button></td>									
										</tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div>
		<br></br>
		
<p>Canceled Appointments</p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>	
										</tr>
									</thead>
									<tbody>
										<tr v-for="appointmentDto in canceledAppointments">
											<td>{{DateSplit(appointmentDto.date)}}</td>
											<td>{{TimeSplit(appointmentDto.timeIntervalDTO.start)}}</td>
											<td>{{appointmentDto.physicianDTO.fullName}}</td>
											<td>{{appointmentDto.roomDTO.name}}</td>
											<td>{{appointmentDto.procedureTypeDTO.name}}</td>
											<td>{{appointmentDto.urgency}}</td>						
										</tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div>
			<br></br>

		<p>Past Appointments</p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="appointmentDto in pastAppointments">
											<td>{{DateSplit(appointmentDto.date)}}</td>
											<td>{{TimeSplit(appointmentDto.timeIntervalDTO.start)}}</td>
											<td>{{appointmentDto.physicianDTO.fullName}}</td>
											<td>{{appointmentDto.roomDTO.name}}</td>
											<td>{{appointmentDto.procedureTypeDTO.name}}</td>
											<td>{{appointmentDto.urgency}}</td>				
                                         </tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div><br></br>

        <p>Avaliable surveys</p>
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Date</th>
											<th>Time</th>
											<th>Physitian</th>
											<th>Room</th>
											<th>Procedure</th>
											<th>Urgency</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="appointmentDto in appointmentsWithoutSurvey">
											<td>{{DateSplit(appointmentDto.date)}}</td>
											<td>{{TimeSplit(appointmentDto.timeIntervalDTO.start)}}</td>
											<td>{{appointmentDto.physicianDTO.fullName}}</td>
											<td>{{appointmentDto.roomDTO.name}}</td>
											<td>{{appointmentDto.procedureTypeDTO.name}}</td>
											<td>{{appointmentDto.urgency}}</td>				
											<td><button  type="button" id="surveyAppointmentButton" class="btn btn-info btn-lg" v-on:click="DoctorNameAndDate(appointmentDto.physicianDTO.fullName,appointmentDto.date);SetSurveyDone(appointmentDto)"  >Survey</button></td>
                                         </tr>
									</tbody>
								</table>
							</div>
						</div>		
					</div>
				</div>
			</div>







		</div>
	</div>
	`,
    methods: {
        ButtonHide: function (patientId, doctorName, date) {
            var dateD = (date.split("T")[0]).split("-")
            var doctorName = doctorName
            dateDate = dateD[0] + "-" + dateD[1] + "-" + dateD[2] + " 00:00:00"
            axios
                .get("/appointment/isSurveyDoneByPatientIdAppointmentDatePhysicianName", { params: { patientId: this.patientId, appointmentDate: dateDate, physicianName: doctorName } })
                .then(response => {

                    if (response.data == true) {
                        alert("usao u true")
                        return false
                    } else {
                        alert("usao u false")

                        return true
                    }
                })
                .catch(error => {
                    alert(error.value);
                })
        },
        SetSurveyDone: function (appointmentDto) {

            axios
                .put("/appointment/setSurveyDoneOnAppointment", appointmentDto)
                .then(response => {
                })
                .catch(error => {
                    alert(error.value);
                })

        },
        DoctorNameAndDate: function (doctorName, date) {
            var dateD = (date.split("T")[0]).split("-")
            doctorNameAppointment = doctorName + "-" + dateD[2] + "." + dateD[1] + "." + dateD[0] + "."
            this.SurveyShow()
        },
        AddNewFeedback: function (feedback) {
            if (!document.getElementById("anonimous").checked)
                this.feedback.patientId = "0003"
            if (feedback.text.localeCompare(null) || feedback.text.localeCompare("")) {
                axios
                    .post("/feedback/add", feedback)
                    .then(response => {
                        this.feedback.text = null;
                        $('#feedbackModal').modal('hide')
                    })
                    .catch(error => {
                        alert("You need to enter a comment first.");
                    })
            }
            else
                alert("You need to enter a comment first.");
        },
        DateSplit: function (date) {
            var dates = (date.split("T")[0]).split("-")
            return dates[2] + "." + dates[1] + "." + dates[0]
        },
        TimeSplit: function (time) {
            var time = time.split("T")[1].split(":")
            return time[0] + ":" + time[1]
        },
        SurveyShow: function () {
            this.$router.push('survey');


        },
        cancelAppointment: function (appointment) {
            axios

                .put("/appointment/cancelAppointment", appointment)
                .then(response => {
                    axios
                        .get('/appointment/IsUserMalicious', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
                        .then(response => {
                            this.isMalicious = response.data
                            if (this.isMalicious == true) {
                                axios
                                    .put('/appointment/SetUserToMalicious', appointment)
                                    .then(response => {
                                    })

                                    .catch(error => {
                                        alert("greska kod activeAppoiuntments")

                                    })
                            }
                        })
                        .catch(error => {
                            alert("greska kod malicious check")

                        })
                    axios
                        .get('/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
                        .then(response => {
                            this.activeAppointments = response.data
                        })

                        .catch(error => {
                            alert("greska kod activeAppoiuntments")

                        })

                    axios
                        .get('/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
                        .then(response => {
                            this.canceledAppointments = response.data

                        })
                        .catch(error => {
                            alert("greska kod canceledAppointments")
                        })
                })
        },
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
                .get('/appointment/appointments', { params: { physicianId: this.choosenPhysician.id, specializationName: this.choosenSpecialization, date: this.date } })
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
        Checkbox: function (id) {
            if (document.getElementById("cbp").checked == true && id == 'cbd')
                document.getElementById("cbp").checked = false
            else if (document.getElementById("cbd").checked == true && id == 'cbp')
                document.getElementById("cbd").checked = false
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
            if (this.timeInterval != null)
                axios
                    .post('/appointment/makeAppointment/' + this.choosenPhysician.id + '/' + this.timeInterval.start + '/' + this.date)
                    .then(response => {
                        this.Refresh()
                        alert("Appointment is made")
                    })
                    .catch(error => {
                        alert("Error")
                    })
        },
        MakeAppointment2: function () {
            if (this.informations != null)
                axios
                    .post('/appointment/makeAppointment/' + this.informations[0].physicianId + '/' + this.informations[1].start + '/' + this.informations[0].date)
                    .then(response => {
                        this.Refresh()
                        alert("Appointment is made")
                    })
                    .catch(error => {
                        alert("Error")
                    })
        },
        Refresh: function () {
            location.reload();
        },
        CreateDates: function () {
            var dateFrom = document.getElementById("dateFrom").value
            var dateTo = document.getElementById("dateTo").value
            var dates = ""
            while (dateFrom != dateTo) {
                dates = dates + dateFrom + ","
                dateFrom = new Date(dateFrom)
                dateFrom.setDate(dateFrom.getDate() + 1)
                var day = dateFrom.getDate()
                var month = dateFrom.getMonth() + 1
                var year = dateFrom.getFullYear()
                dateFrom = year + "-" + month + "-" + day
            }
            dates = dates + dateTo
            return dates
        },
        DisplayAppointments: function () {
            if (this.Validation2()) {
                this.display = true;
                if (document.getElementById("cbd").checked == true) {
                    var dates = this.CreateDates()
                    axios
                        .get('/appointment/appointmentsWithReccomendation', { params: { physicianId: this.choosenPhysician.id, specializationName: this.choosenSpecialization, dates: dates } })
                        .then(response => {
                            this.appointmentDto = response.data
                        })
                } else {
                    var dates = this.CreateDates()
                    axios
                        .get('/appointment/appointmentsWithPhysicianPriority', { params: { physicianId: this.choosenPhysician.id, specializationName: this.choosenSpecialization, dates: dates } })
                        .then(response => {
                            this.appointmentDto = response.data
                        })
                }

            }
        },
        Validation2: function () {
            this.ErrorMessages()
            if (document.getElementById("dateFrom").value == "" || document.getElementById("dateTo").value == "" || document.getElementById("selectSpecialization").value == "" || document.getElementById("selectPhysician").value == "")
                return false
            if (document.getElementById("dateFrom").value > document.getElementById("dateTo").value)
                return false
            if (document.getElementById("cbp").checked == false && document.getElementById("cbd").checked == false)
                return false
            return true
        },
        ErrorMessages: function () {
            if (document.getElementById("dateFrom").value == "" || document.getElementById("dateTo").value == "" || document.getElementById("dateFrom").value > document.getElementById("dateTo").value) {
                document.getElementById("validationDates").className = "error"
            } else {
                document.getElementById("validationDates").className = "correct"
            }
            if (document.getElementById("selectSpecialization").value == "") {
                document.getElementById("validationSpecialization").className = "error"
            } else {
                document.getElementById("validationSpecialization").className = "correct"
            }
            if (document.getElementById("selectPhysician").value == "") {
                document.getElementById("validationPhysician").className = "error"
            } else {
                document.getElementById("validationPhysician").className = "correct"
            }
            if (document.getElementById("cbp").checked == false && document.getElementById("cbd").checked == false) {
                document.getElementById("validationParameter").className = "error"
            } else {
                document.getElementById("validationParameter").className = "correct"
            }
        },
        DisplayAppointmentsMyChoosenDoctor: function () {
            if (document.getElementById("myDate").value != "") {
                this.myDate = document.getElementById("myDate").value;
                this.display1 = true;
                axios
                    .get('/appointment/appointments', {
                        params: {
                            physicianId: "600001", specializationName: "General practitioner", date: document.getElementById("myDate").value
                        }
                    })
                    .then(response => {
                        this.timeIntervals = response.data
                    })
            }
        },
        MakeAppointment3: function () {
            axios
                .post('/appointment/makeAppointment/' + "600001" + '/' + this.timeInterval.start + '/' + this.myDate)
                .then(response => {
                    this.Refresh()
                })
        }
    }
});