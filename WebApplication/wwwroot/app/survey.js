Vue.component("survey", {
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
                <p>The doctor is welcoming and gentle?</p>
                <input type="radio" name="behavior" id="a1" value="1">
                <label for="a1"></label>
                <input type="radio" name="behavior" id="a2" value="2">
                <label for="a2"></label>
                <input type="radio" name="behavior" id="a3" value="3">
                <label for="a3"></label>
                <input type="radio" name="behavior" id="a4" value="4">
                <label for="a4"></label>
                <input type="radio" name="behavior" id="a5" value="5">
                <label for="a5"></label>
              </div>

              <div class="question" id="q">
                <p>The doctor answered all of your questions in an understandable manner?</p>
                <input type="radio" name="manner" id="c1" value="1">
                <label for="c1"></label>
                <input type="radio" name="manner" id="c2" value="2">
                <label for="c2"></label>
                <input type="radio" name="manner" id="c3" value="3">
                <label for="c3"></label>
                <input type="radio" name="manner" id="c4" value="4">
                <label for="c4"></label>
                <input type="radio" name="manner" id="c5" value="5">
                <label for="c5"></label>
              </div>


             <div class="question" id="q">
                <p>The doctor takes care of you in a professional manner?</p>
                <input type="radio" name="professionalism" id="d1" value="1">
                <label for="d1"></label>
                <input type="radio" name="professionalism" id="d2" value="2">
                <label for="d2"></label>
                <input type="radio" name="professionalism" id="d3" value="3">
                <label for="d3"></label>
                <input type="radio" name="professionalism" id="d4" value="4">
                <label for="d4"></label>
                <input type="radio" name="professionalism" id="d5" value="5">
                <label for="d5"></label>
              </div>

            <div class="question" id="q">
                <p>Would you have the procedure done again by this doctor?</p>
                <input type="radio" name="again" id="e1" value="1">
                <label for="e1"></label>
                <input type="radio" name="again" id="e2" value="2">
                <label for="e2"></label>
                <input type="radio" name="again" id="e3" value="3">
                <label for="e3"></label>
                <input type="radio" name="again" id="e4" value="4">
                <label for="e4"></label>
                <input type="radio" name="again" id="e5" value="5">
                <label for="e5"></label>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 2 Nurse's care</b>
                <p>The personal manner(courtosy,respect,sensitivity,friendliness) of the nurses and other support staff</p>
                <input type="radio" name="nurses" id="f1" value="1">
                <label for="f1"></label>
                <input type="radio" name="nurses" id="f2" value="2">
                <label for="f2"></label>
                <input type="radio" name="nurses" id="f3" value="3">
                <label for="f3"></label>
                <input type="radio" name="nurses" id="f4" value="4">
                <label for="f4"></label>
                <input type="radio" name="nurses" id="f5" value="5">
                <label for="f5"></label>
              </div>

              <div class="question" id="q">
                <p>The nursees answered all of your questions in an understandable manner?</p>
                <input type="radio" name="nursesAnswer" id="g1" value="1">
                <label for="g1"></label>
                <input type="radio" name="nursesAnswer" id="g2" value="2">
                <label for="g2"></label>
                <input type="radio" name="nursesAnswer" id="g3" value="3">
                <label for="g3"></label>
                <input type="radio" name="nursesAnswer" id="g4" value="4">
                <label for="g4"></label>
                <input type="radio" name="nursesAnswer" id="g5" value="5">
                <label for="g5"></label>
              </div>

              <div class="question" id="q">
                <p>Orientation given to warn setup</p>
                <input type="radio" name="setup" id="h1" value="1">
                <label for="h1"></label>
                <input type="radio" name="setup" id="h2" value="2">
                <label for="h2"></label>
                <input type="radio" name="setup" id="h3" value="3">
                <label for="h3"></label>
                <input type="radio" name="setup" id="h4" value="4">
                <label for="h4"></label>
                <input type="radio" name="setup" id="h5" value="5">
                <label for="h5"></label>
              </div>


             <div class="question" id="q">
                <p>The nurse gave you good discharge instructions</p>
                <input type="radio" name="instructions" id="i1" value="1">
                <label for="i1"></label>
                <input type="radio" name="instructions" id="i2" value="2">
                <label for="i2"></label>
                <input type="radio" name="instructions" id="i3" value="3">
                <label for="i3"></label>
                <input type="radio" name="instructions" id="i4" value="4">
                <label for="i4"></label>
                <input type="radio" name="instructions" id="i5" value="5">
                <label for="i5"></label>
              </div>

            <div class="question" id="q">
                <p>The nurse was concern for you?</p>
                <input type="radio" name="concern" id="j1" value="1">
                <label for="j1"></label>
                <input type="radio" name="concern" id="j2" value="2">
                <label for="j2"></label>
                <input type="radio" name="concern" id="j3" value="3">
                <label for="j3"></label>
                <input type="radio" name="concern" id="j4" value="4">
                <label for="j4"></label>
                <input type="radio" name="concern" id="j5" value="5">
                <label for="j5"></label>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 3 Clinic's hygiene and ambience</b>
                <p>The comfort and cleanliness of the facility </p>
                <input type="radio" name="hygiene" id="k1" value="1">
                <label for="k1"></label>
                <input type="radio" name="hygiene" id="k2" value="2">
                <label for="k2"></label>
                <input type="radio" name="hygiene" id="k3" value="3">
                <label for="k3"></label>
                <input type="radio" name="hygiene" id="k4" value="4">
                <label for="k4"></label>
                <input type="radio" name="hygiene" id="k5" value="5">
                <label for="k5"></label>
              </div>

              <div class="question" id="q">
                <p> Comfort level within the procedure room?</p>
                <input type="radio" name="Comfort" id="l1" value="1">
                <label for="l1"></label>
                <input type="radio" name="Comfort" id="l2" value="2">
                <label for="l2"></label>
                <input type="radio" name="Comfort" id="l3" value="3">
                <label for="l3"></label>
                <input type="radio" name="Comfort" id="l4" value="4">
                <label for="l4"></label>
                <input type="radio" name="Comfort" id="l5" value="5">
                <label for="l5"></label>
              </div>

              <div class="question" id="q">
                <p>Conditions of the rooms(temperature,comfort,silence)</p>
                <input type="radio" name="Conditions" id="m1" value="1">
                <label for="m1"></label>
                <input type="radio" name="Conditions" id="m2" value="2">
                <label for="m2"></label>
                <input type="radio" name="Conditions" id="m3" value="3">
                <label for="m3"></label>
                <input type="radio" name="Conditions" id="m4" value="4">
                <label for="m4"></label>
                <input type="radio" name="Conditions" id="m5" value="5">
                <label for="m5"></label>
              </div>


             <div class="question" id="q">
                <p>General impression of the ambient atmosphere</p>
                <input type="radio" name="atmosphere" id="n1" value="1">
                <label for="n1"></label>
                <input type="radio" name="atmosphere" id="n2" value="2">
                <label for="n2"></label>
                <input type="radio" name="atmosphere" id="n3" value="3">
                <label for="n3"></label>
                <input type="radio" name="atmosphere" id="n4" value="4">
                <label for="n4"></label>
                <input type="radio" name="atmosphere" id="n5" value="5">
                <label for="n5"></label>
              </div>

            <div class="question" id="q">
              <b id="topic">Toping 4 Clinic's pharmacy supplies and equipment </b>
                <p>Do you think the clinic has the necessary equipment</p>
                <input type="radio" name="equipment" id="o1" value="1">
                <label for="o1"></label>
                <input type="radio" name="equipment" id="o2" value="2">
                <label for="o2"></label>
                <input type="radio" name="equipment" id="o3" value="3">
                <label for="o3"></label>
                <input type="radio" name="equipment" id="o4" value="4">
                <label for="o4"></label>
                <input type="radio" name="equipment" id="o5" value="5">
                <label for="o5"></label>
              </div>

              <div class="question" id="q">
                <p> Do you think the clinic's farmacy has the necessary drugs?</p>
                <input type="radio" name="drugs" id="p1" value="1">
                <label for="p1"></label>
                <input type="radio" name="drugs" id="p2" value="2">
                <label for="p2"></label>
                <input type="radio" name="drugs" id="p3" value="3">
                <label for="p3"></label>
                <input type="radio" name="drugs" id="p4" value="4">
                <label for="p4"></label>
                <input type="radio" name="drugs" id="p5" value="5">
                <label for="p5"></label>
              </div>

              <div class="question" id="q">
                <p>Do you think that the hospital should have more modern equipment than the current one</p>
                <input type="radio" name="betterEquipment" id="q1" value="1">
                <label for="q1"></label>
                <input type="radio" name="betterEquipment" id="q2" value="2">
                <label for="q2"></label>
                <input type="radio" name="betterEquipment" id="q3" value="3">
                <label for="q3"></label>
                <input type="radio" name="betterEquipment" id="q4" value="4">
                <label for="q4"></label>
                <input type="radio" name="betterEquipment" id="q5" value="5">
                <label for="q5"></label>
              </div>


             <div class="question" id="q">
                <p>Did you noticed broken or damaged equipment in the hospital</p>
                <input type="radio" name="brokenOrDemaged" id="r1" value="1">
                <label for="r1"></label>
                <input type="radio" name="brokenOrDemaged" id="r2" value="2">
                <label for="r2"></label>
                <input type="radio" name="brokenOrDemaged" id="r3" value="3">
                <label for="r3"></label>
                <input type="radio" name="brokenOrDemaged" id="r4" value="4">
                <label for="r4"></label>
                <input type="radio" name="brokenOrDemaged" id="r5" value="5">
                <label for="r5"></label>
              </div>

            <div class="question" id="q">
                <p>The doctor prescribed medications that I could buy at the clinic's pharmacy</p>
                <input type="radio" name="pharmacyDrugs" id="s1" value="1">
                <label for="s1"></label>
                <input type="radio" name="pharmacyDrugs" id="s2" value="2">
                <label for="s2"></label>
                <input type="radio" name="pharmacyDrugs" id="s3" value="3">
                <label for="s3"></label>
                <input type="radio" name="pharmacyDrugs" id="s4" value="4">
                <label for="s4"></label>
                <input type="radio" name="pharmacyDrugs" id="s5" value="5">
                <label for="s5"></label>
              </div>

           <div class="question" id="q">
              <b id="topic">Toping 5 Website </b>
                <p>Did you found it easy to use our website</p>
                <input type="radio" name="website" id="t1" value="1">
                <label for="t1"></label>
                <input type="radio" name="website" id="t2" value="2">
                <label for="t2"></label>
                <input type="radio" name="website" id="t3" value="3">
                <label for="t3"></label>
                <input type="radio" name="website" id="t4" value="4">
                <label for="t4"></label>
                <input type="radio" name="website" id="t5" value="5">
                <label for="t5"></label>
              </div>

              <div class="question" id="q">
                <p> Did you have found all the necessary information on our website?</p>
                <input type="radio" name="informations" id="u1" value="1">
                <label for="u1"></label>
                <input type="radio" name="informations" id="u2" value="2">
                <label for="u2"></label>
                <input type="radio" name="informations" id="u3" value="3">
                <label for="u3"></label>
                <input type="radio" name="informations" id="u4" value="4">
                <label for="u4"></label>
                <input type="radio" name="informations" id="u5" value="5">
                <label for="u5"></label>
              </div>

              <div class="question" id="q">
                <b id="topic">Toping 6 General opinion </b>
                <p>Overall, are you satisfied with the care you received in this facility?</p>
                <input type="radio" name="satisfied" id="v1" value="1">
                <label for="v1"></label>
                <input type="radio" name="satisfied" id="v2" value="2">
                <label for="v2"></label>
                <input type="radio" name="satisfied" id="v3" value="3">
                <label for="v3"></label>
                <input type="radio" name="satisfied" id="v4" value="4">
                <label for="v4"></label>
                <input type="radio" name="satisfied" id="v5" value="5">
                <label for="v5"></label>
              </div>


             <div class="question" id="q">
                <p>Would you come to this institution again</p>
                <input type="radio" name="again1" id="w1" value="1">
                <label for="w1"></label>
                <input type="radio" name="again1" id="w2" value="2">
                <label for="w2"></label>
                <input type="radio" name="again1" id="w3" value="3">
                <label for="w3"></label>
                <input type="radio" name="again1" id="w4" value="4">
                <label for="w4"></label>
                <input type="radio" name="again1" id="w5" value="5">
                <label for="w5"></label>
              </div>

            <div class="question" id="q">
                <p>Would you recommend this facility to your friends and family</p>
                <input type="radio" name="recomendation" id="x1" value="1">
                <label for="x1"></label>
                <input type="radio" name="recomendation" id="x2" value="2">
                <label for="x2"></label>
                <input type="radio" name="recomendation" id="x3" value="3">
                <label for="x3"></label>
                <input type="radio" name="recomendation" id="x4" value="4">
                <label for="x4"></label>
                <input type="radio" name="recomendation" id="x5" value="5">
                <label for="x5"></label>
              </div>


              <input type="submit" value="ok" id="submit">
              <input type="submit" value="cancel" id="cancel">
        </div>
    </div>
	`,
    methods: {

    }
});