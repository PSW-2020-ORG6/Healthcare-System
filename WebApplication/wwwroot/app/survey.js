﻿Vue.component("survey", {
    data: function () {
        return {
        }
    },
    beforeMount() {

    },
    template: `
    <div class="container">
        <p id="title">Survey</p>
        <div>
            <p id="textSurvey">Dear patient,<br>
               At Health Clinic,we are commited to your healthcare.We are interested in knowing what do you thing abaut our services.
                You performance by completing this survey regarding your visit.<br>Thank you for taking time to share your expirience with us.<br><br>
               Please rate the following toppings on a scale of 1 to 5,with 1 being poor and 5 being exellent.
            </p>
            <div class="question" id="q">
              <b id="topic">Toping 1 Doctor</b>
                <p>1.The doctor is welcoming and gentle?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingOne" name="ratingOne" value="5" /><label for="star1RatingOne" title="5 star"></label>
                        <input type="radio" id="star2RatingOne" name="ratingOne" value="4" /><label for="star2RatingOne" title="4 star"></label>
                        <input type="radio" id="star3RatingOne" name="ratingOne" value="3" /><label for="star3RatingOne" title="3 star"></label>
                        <input type="radio" id="star4RatingOne" name="ratingOne" value="2" /><label for="star4RatingOne" title="2 star"></label>
                        <input type="radio" id="star5RatingOne" name="ratingOne" value="1" /><label for="star5RatingOne" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>2.The doctor answered all of your questions in an understandable manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwo" name="ratingTwo" value="5" /><label for="star1RatingTwo" title="5 star"></label>
                        <input type="radio" id="star2RatingTwo" name="ratingTwo" value="4" /><label for="star2RatingTwo" title="4 star"></label>
                        <input type="radio" id="star3RatingTwo" name="ratingTwo" value="3" /><label for="star3RatingTwo" title="3 star"></label>
                        <input type="radio" id="star4RatingTwo" name="ratingTwo" value="2" /><label for="star4RatingTwo" title="2 star"></label>
                        <input type="radio" id="star5RatingTwo" name="ratingTwo" value="1" /><label for="star5RatingTwo" title="1 star"></label>
                    </div>
              </div>


             <div class="question" id="q">
                <p>3.The doctor takes care of you in a professional manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingThree" name="ratingThree" value="5" /><label for="star1RatingThree" title="5 star"></label>
                        <input type="radio" id="star2RatingThree" name="ratingThree" value="4" /><label for="star2RatingThree" title="4 star"></label>
                        <input type="radio" id="star3RatingThree" name="ratingThree" value="3" /><label for="star3RatingThree" title="3 star"></label>
                        <input type="radio" id="star4RatingThree" name="ratingThree" value="2" /><label for="star4RatingThree" title="2 star"></label>
                        <input type="radio" id="star5RatingThree" name="ratingThree" value="1" /><label for="star5RatingThree" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
                <p>4.Would you have the procedure done again by this doctor?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFour" name="ratingFour" value="5" /><label for="star1RatingFour" title="5 star"></label>
                        <input type="radio" id="star2RatingFour" name="ratingFour" value="4" /><label for="star2RatingFour" title="4 star"></label>
                        <input type="radio" id="star3RatingFour" name="ratingFour" value="3" /><label for="star3RatingFour" title="3 star"></label>
                        <input type="radio" id="star4RatingFour" name="ratingFour" value="2" /><label for="star4RatingFour" title="2 star"></label>
                        <input type="radio" id="star5RatingFour" name="ratingFour" value="1" /><label for="star5RatingFour" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 2 Nurse's care</b>
                <p>5.The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFive" name="ratingFive" value="5" /><label for="star1RatingFive" title="5 star"></label>
                        <input type="radio" id="star2RatingFive" name="ratingFive" value="4" /><label for="star2RatingFive" title="4 star"></label>
                        <input type="radio" id="star3RatingFive" name="ratingFive" value="3" /><label for="star3RatingFive" title="3 star"></label>
                        <input type="radio" id="star4RatingFive" name="ratingFive" value="2" /><label for="star4RatingFive" title="2 star"></label>
                        <input type="radio" id="star5RatingFive" name="ratingFive" value="1" /><label for="star5RatingFive" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>6.The nursees answered all of your questions in an understandable manner?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSix" name="ratingSix" value="5" /><label for="star1RatingSix" title="5 star"></label>
                        <input type="radio" id="star2RatingSix" name="ratingSix" value="4" /><label for="star2RatingSix" title="4 star"></label>
                        <input type="radio" id="star3RatingSix" name="ratingSix" value="3" /><label for="star3RatingSix" title="3 star"></label>
                        <input type="radio" id="star4RatingSix" name="ratingSix" value="2" /><label for="star4RatingSix" title="2 star"></label>
                        <input type="radio" id="star5RatingSix" name="ratingSix" value="1" /><label for="star5RatingSix" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>7.Orientation given to warn setup</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSeven" name="ratingSeven" value="5" /><label for="star1RatingSeven" title="5 star"></label>
                        <input type="radio" id="star2RatingSeven" name="ratingSeven" value="4" /><label for="star2RatingSeven" title="4 star"></label>
                        <input type="radio" id="star3RatingSeven" name="ratingSeven" value="3" /><label for="star3RatingSeven" title="3 star"></label>
                        <input type="radio" id="star4RatingSeven" name="ratingSeven" value="2" /><label for="star4RatingSeven" title="2 star"></label>
                        <input type="radio" id="star5RatingSeven" name="ratingSeven" value="1" /><label for="star5RatingSeven" title="1 star"></label>
                    </div>
              </div>


             <div class="question" id="q">
                <p>8.The nurse gave you good discharge instructions</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEight" name="ratingEight" value="5" /><label for="star1RatingEight" title="5 star"></label>
                        <input type="radio" id="star2RatingEight" name="ratingEight" value="4" /><label for="star2RatingEight" title="4 star"></label>
                        <input type="radio" id="star3RatingEight" name="ratingEight" value="3" /><label for="star3RatingEight" title="3 star"></label>
                        <input type="radio" id="star4RatingEight" name="ratingEight" value="2" /><label for="star4RatingEight" title="2 star"></label>
                        <input type="radio" id="star5RatingEight" name="ratingEight" value="1" /><label for="star5RatingEight" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
                <p>9.The nurse was concerned for you?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingNine" name="ratingNine" value="5" /><label for="star1RatingNine" title="5 star"></label>
                        <input type="radio" id="star2RatingNine" name="ratingNine" value="4" /><label for="star2RatingNine" title="4 star"></label>
                        <input type="radio" id="star3RatingNine" name="ratingNine" value="3" /><label for="star3RatingNine" title="3 star"></label>
                        <input type="radio" id="star4RatingNine" name="ratingNine" value="2" /><label for="star4RatingNine" title="2 star"></label>
                        <input type="radio" id="star5RatingNine" name="ratingNine" value="1" /><label for="star5RatingNine" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 3 Clinic's hygiene and ambience</b>
                <p>10.The comfort and cleanliness of the facility </p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTen" name="ratingTen" value="5" /><label for="star1RatingTen" title="5 star"></label>
                        <input type="radio" id="star2RatingTen" name="ratingTen" value="4" /><label for="star2RatingTen" title="4 star"></label>
                        <input type="radio" id="star3RatingTen" name="ratingTen" value="3" /><label for="star3RatingTen" title="3 star"></label>
                        <input type="radio" id="star4RatingTen" name="ratingTen" value="2" /><label for="star4RatingTen" title="2 star"></label>
                        <input type="radio" id="star5RatingTen" name="ratingTen" value="1" /><label for="star5RatingTen" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>11.Comfort level within the procedure room?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEleven" name="ratingEleven" value="5" /><label for="star1RatingEleven" title="5 star"></label>
                        <input type="radio" id="star2RatingEleven" name="ratingEleven" value="4" /><label for="star2RatingEleven" title="4 star"></label>
                        <input type="radio" id="star3RatingEleven" name="ratingEleven" value="3" /><label for="star3RatingEleven" title="3 star"></label>
                        <input type="radio" id="star4RatingEleven" name="ratingEleven" value="2" /><label for="star4RatingEleven" title="2 star"></label>
                        <input type="radio" id="star5RatingEleven" name="ratingEleven" value="1" /><label for="star5RatingEleven" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>12.Conditions of the rooms(temperature,comfort,silence)</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwelve" name="ratingTwelve" value="5" /><label for="star1RatingTwelve" title="5 star"></label>
                        <input type="radio" id="star2RatingTwelve" name="ratingTwelve" value="4" /><label for="star2RatingTwelve" title="4 star"></label>
                        <input type="radio" id="star3RatingTwelve" name="ratingTwelve" value="3" /><label for="star3RatingTwelve" title="3 star"></label>
                        <input type="radio" id="star4RatingTwelve" name="ratingTwelve" value="2" /><label for="star4RatingTwelve" title="2 star"></label>
                        <input type="radio" id="star5RatingTwelve" name="ratingTwelve" value="1" /><label for="star5RatingTwelve" title="1 star"></label>
                    </div>
              </div>


             <div class="question" id="q">
                <p>13.General impression of the ambient atmosphere</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingThirteen" name="ratingThirteen" value="5" /><label for="star1RatingThirteen" title="5 star"></label>
                        <input type="radio" id="star2RatingThirteen" name="ratingThirteen" value="4" /><label for="star2RatingThirteen" title="4 star"></label>
                        <input type="radio" id="star3RatingThirteen" name="ratingThirteen" value="3" /><label for="star3RatingThirteen" title="3 star"></label>
                        <input type="radio" id="star4RatingThirteen" name="ratingThirteen" value="2" /><label for="star4RatingThirteen" title="2 star"></label>
                        <input type="radio" id="star5RatingThirteen" name="ratingThirteen" value="1" /><label for="star5RatingThirteen" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 4 Clinic's pharmacy supplies and equipment </b>
                <p>14.Do you think the clinic has the necessary equipment</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFourteen" name="ratingFourteen" value="5" /><label for="star1RatingFourteen" title="5 star"></label>
                        <input type="radio" id="star2RatingFourteen" name="ratingFourteen" value="4" /><label for="star2RatingFourteen" title="4 star"></label>
                        <input type="radio" id="star3RatingFourteen" name="ratingFourteen" value="3" /><label for="star3RatingFourteen" title="3 star"></label>
                        <input type="radio" id="star4RatingFourteen" name="ratingFourteen" value="2" /><label for="star4RatingFourteen" title="2 star"></label>
                        <input type="radio" id="star5RatingFourteen" name="ratingFourteen" value="1" /><label for="star5RatingFourteen" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>15.Do you think the clinic's farmacy has the necessary drugs?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingFifteen" name="ratingFifteen" value="5" /><label for="star1RatingFifteen" title="5 star"></label>
                        <input type="radio" id="star2RatingFifteen" name="ratingFifteen" value="4" /><label for="star2RatingFifteen" title="4 star"></label>
                        <input type="radio" id="star3RatingFifteen" name="ratingFifteen" value="3" /><label for="star3RatingFifteen" title="3 star"></label>
                        <input type="radio" id="star4RatingFifteen" name="ratingFifteen" value="2" /><label for="star4RatingFifteen" title="2 star"></label>
                        <input type="radio" id="star5RatingFifteen" name="ratingFifteen" value="1" /><label for="star5RatingFifteen" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>16.Do you think that the hospital should have more modern equipment than the current one</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSixteen" name="ratingSixteen" value="5" /><label for="star1RatingSixteen" title="5 star"></label>
                        <input type="radio" id="star2RatingSixteen" name="ratingSixteen" value="4" /><label for="star2RatingSixteen" title="4 star"></label>
                        <input type="radio" id="star3RatingSixteen" name="ratingSixteen" value="3" /><label for="star3RatingSixteen" title="3 star"></label>
                        <input type="radio" id="star4RatingSixteen" name="ratingSixteen" value="2" /><label for="star4RatingSixteen" title="2 star"></label>
                        <input type="radio" id="star5RatingSixteen" name="ratingSixteen" value="1" /><label for="star5RatingSixteen" title="1 star"></label>
                    </div>
              </div>


             <div class="question" id="q">
                <p>17.Did you noticed broken or damaged equipment in the hospital</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingSeventeen" name="ratingSeventeen" value="5" /><label for="star1RatingSeventeen" title="5 star"></label>
                        <input type="radio" id="star2RatingSeventeen" name="ratingSeventeen" value="4" /><label for="star2RatingSeventeen" title="4 star"></label>
                        <input type="radio" id="star3RatingSeventeen" name="ratingSeventeen" value="3" /><label for="star3RatingSeventeen" title="3 star"></label>
                        <input type="radio" id="star4RatingSeventeen" name="ratingSeventeen" value="2" /><label for="star4RatingSeventeen" title="2 star"></label>
                        <input type="radio" id="star5RatingSeventeen" name="ratingSeventeen" value="1" /><label for="star5RatingSeventeen" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
                <p>18.The doctor prescribed medications that I could buy at the clinic's pharmacy</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingEighteen" name="ratingEighteen" value="5" /><label for="star1RatingEighteen" title="5 star"></label>
                        <input type="radio" id="star2RatingEighteen" name="ratingEighteen" value="4" /><label for="star2RatingEighteen" title="4 star"></label>
                        <input type="radio" id="star3RatingEighteen" name="ratingEighteen" value="3" /><label for="star3RatingEighteen" title="3 star"></label>
                        <input type="radio" id="star4RatingEighteen" name="ratingEighteen" value="2" /><label for="star4RatingEighteen" title="2 star"></label>
                        <input type="radio" id="star5RatingEighteen" name="ratingEighteen" value="1" /><label for="star5RatingEighteen" title="1 star"></label>
                    </div>
              </div>

           <div class="question" id="q">
              <b id="topic">Toping 5 Website </b>
                <p>19.Did you found it easy to use our website</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingNineteen" name="ratingNineteen" value="5" /><label for="star1RatingNineteen" title="5 star"></label>
                        <input type="radio" id="star2RatingNineteen" name="ratingNineteen" value="4" /><label for="star2RatingNineteen" title="4 star"></label>
                        <input type="radio" id="star3RatingNineteen" name="ratingNineteen" value="3" /><label for="star3RatingNineteen" title="3 star"></label>
                        <input type="radio" id="star4RatingNineteen" name="ratingNineteen" value="2" /><label for="star4RatingNineteen" title="2 star"></label>
                        <input type="radio" id="star5RatingNineteen" name="ratingNineteen" value="1" /><label for="star5RatingNineteen" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <p>20.Did you have found all the necessary information on our website?</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwenty" name="ratingTwenty" value="5" /><label for="star1RatingTwenty" title="5 star"></label>
                        <input type="radio" id="star2RatingTwenty" name="ratingTwenty" value="4" /><label for="star2RatingTwenty" title="4 star"></label>
                        <input type="radio" id="star3RatingTwenty" name="ratingTwenty" value="3" /><label for="star3RatingTwenty" title="3 star"></label>
                        <input type="radio" id="star4RatingTwenty" name="ratingTwenty" value="2" /><label for="star4RatingTwenty" title="2 star"></label>
                        <input type="radio" id="star5RatingTwenty" name="ratingTwenty" value="1" /><label for="star5RatingTwenty" title="1 star"></label>
                    </div>
              </div>

              <div class="question" id="q">
                <b id="topic">Toping 6 General opinion </b>
                <p>21.Overall, are you satisfied with the care you received in this facility?</p>
                    <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyOne" name="ratingTwentyOne" value="5" /><label for="star1RatingTwentyOne" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyOne" name="ratingTwentyOne" value="4" /><label for="star2RatingTwentyOne" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyOne" name="ratingTwentyOne" value="3" /><label for="star3RatingTwentyOne" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyOne" name="ratingTwentyOne" value="2" /><label for="star4RatingTwentyOne" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyOne" name="ratingTwentyOne" value="1" /><label for="star5RatingTwentyOne" title="1 star"></label>
                    </div>
              </div>


             <div class="question" id="q">
                <p>22.Would you come to this institution again</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyTwo" name="ratingTwentyTwo" value="5" /><label for="star1RatingTwentyTwo" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyTwo" name="ratingTwentyTwo" value="4" /><label for="star2RatingTwentyTwo" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyTwo" name="ratingTwentyTwo" value="3" /><label for="star3RatingTwentyTwo" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyTwo" name="ratingTwentyTwo" value="2" /><label for="star4RatingTwentyTwo" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyTwo" name="ratingTwentyTwo" value="1" /><label for="star5RatingTwentyTwo" title="1 star"></label>
                    </div>
              </div>

            <div class="question" id="q">
                <p>23.Would you recommend this facility to your friends and family</p>
                     <div class="starrating risingstar d-flex justify-content-center flex-row-reverse">
                        <input type="radio" id="star1RatingTwentyThree" name="ratingTwentyThree" value="5" /><label for="star5RatingTwentyThree" title="5 star"></label>
                        <input type="radio" id="star2RatingTwentyThree" name="ratingTwentyThree" value="4" /><label for="star4RatingTwentyThree" title="4 star"></label>
                        <input type="radio" id="star3RatingTwentyThree" name="ratingTwentyThree" value="3" /><label for="star3RatingTwentyThree" title="3 star"></label>
                        <input type="radio" id="star4RatingTwentyThree" name="ratingTwentyThree" value="2" /><label for="star2RatingTwentyThree" title="2 star"></label>
                        <input type="radio" id="star5RatingTwentyThree" name="ratingTwentyThree" value="1" /><label for="star1RatingTwentyThree" title="1 star"></label>
                    </div>
              </div>


              <input type="submit" value="ok" id="submit">
              <input type="submit" value="cancel" id="cancel">
        </div>
    </div>
	`,
    methods: {

    }
});