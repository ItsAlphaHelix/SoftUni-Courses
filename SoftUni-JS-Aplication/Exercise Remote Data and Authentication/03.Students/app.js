const url = `http://localhost:3030/jsonstore/collections/students`;

async function addStudentInfo() {

    const tableElement = document.querySelector('#results tbody');
    const response = await fetch(url);
    const data = await response.json();

    tableElement.innerHTML = '';

    Object.values(data).forEach(data => {

        const firstName = data.firstName;
        const lastName = data.lastName;
        const facultyNumber = data.facultyNumber;
        const grade = Number(data.grade);

        const trElement = document.createElement('tr');
        tableElement.appendChild(trElement);

        const tdFirstNameElement = document.createElement('td');
        tdFirstNameElement.innerText = firstName;
        trElement.appendChild(tdFirstNameElement);

        const tdLastNameElement = document.createElement('td');
        tdLastNameElement.innerText = lastName;
        trElement.appendChild(tdLastNameElement);

        const tdFacultyNumber = document.createElement('td');
        tdFacultyNumber.innerText = facultyNumber;
        trElement.appendChild(tdFacultyNumber);

        const tdGradeElement = document.createElement('td');
        tdGradeElement.innerText = grade;
        trElement.appendChild(tdGradeElement);

        

    });

    document.getElementById('submit').addEventListener('click', submitInforamtion);
}

async function submitInforamtion(event) {

    event.preventDefault();
    const inputElements = document.querySelectorAll('.inputs input');

    const form = new FormData(event.target.parentNode);
    const grade = form.get('grade');

    if (isNaN(grade)) {
        return;
    }

    const studenRequestBody = {

        firstName: form.get('firstName'),
        lastName: form.get('lastName'),
        facultyNumber: form.get('facultyNumber'),
        grade,
    };

    if(studenRequestBody.firstName == '' || studenRequestBody.lastName == '' || studenRequestBody.facultyNumber == '' || studenRequestBody.grade == '') {

        return;

    }

    await fetch(url, {

        method: 'POST',
        headers: {

            'Content-Type': 'aplication/json'

        },
        body: JSON.stringify(studenRequestBody)

    });

    Array.from(inputElements).map(x => x.value = '');
    
    addStudentInfo();

}
addStudentInfo();