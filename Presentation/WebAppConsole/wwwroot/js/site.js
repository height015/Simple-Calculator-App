//document.addEventListener('DOMContentLoaded', () => {
//    let operand1 = '';
//    let operator = '';
//    let operand2 = '';

//    const inputDisplay = document.getElementById('input');
//    const resultDisplay = document.getElementById('result');

//    const resetInput = () => {
//        operand1 = '';
//        operator = '';
//        operand2 = '';
//        resultDisplay.innerText = '';
//    }

//    const backSpace = (operand) => {
//        return operand.slice(0, -1);
//    }

//    const calculate = () => {
//        if (operand1 && operator && operand2) {
//            const num1 = parseFloat(operand1);
//            const num2 = parseFloat(operand2);
//            result = eval(operand1, operator, operand2);
//            document.getElementById('result').innerText = result;
//            // Send the calculation to the API and update resultDisplay with the result from the API
//            // You can make an API request here and handle the response
//        }
//    }

//    const handleNumericInput = (text) => {
//        const currentOperand = operator ? 'operand2' : 'operand1';
//        const currentInput = eval(currentOperand);
//        if (text === '.' && (operator || currentInput.includes('.'))) {
//            return; // Allow only one decimal point for each operand
//        }
//        if (operator) {
//            eval( + `+= '${text}'`);
//        } else {
//            if (currentInput === '0') {
//                operand1 = text;
//            } else {
//                operand1 += text;
//            }
//        }
//        updateDisplay();
//    }

//    const handleOperatorInput = (text) => {
//        if (!operand1) return;
//        if (operator && operand2) {
//            calculate();
//        }
//        operator = text;
//        updateDisplay();
//    }

//    const updateDisplay = () => {
//        inputDisplay.textContent = operand1 + ' ' + operator + ' ' + operand2;
//    }

//    document.querySelectorAll('.btn').forEach(button => {
//        button.addEventListener('click', function () {
//            const buttonText = this.textContent;
//            if (/\d/.test(buttonText) || buttonText === '.') {
//                handleNumericInput(buttonText);
//            } else if (['+', '-', '*', '/'].includes(buttonText)) {
//                handleOperatorInput(buttonText);
//            } else if (buttonText === '=') {
//                calculate();
//            } else if (buttonText === 'Clear') {
//                resetInput();
//            } else if (buttonText === 'DEL') {
//                const currentOperand = operator ? 'operand2' : 'operand1';
//                eval(currentOperand + ' = ' + currentOperand + '.slice(0, -1)');
//                updateDisplay();
//            }
//        });
//    });
//});


let operand1 = '';
let operator = '';
let operand2 = '';

document.addEventListener('DOMContentLoaded', (event) => {
    const resultElement = document.getElementById('result');
    const inputElement = document.getElementById('input');

    const resetInput = () => {
        operand1 = '';
        operator = '';
        operand2 = '';
        resultElement.textContent = '';
        updateDisplay();
    }

    const backSpace = (operand) => operand.slice(0, -1);

    async function calculate() {
        if (!operand1 || !operator || !operand2) {
            alert('Please enter valid operands and operator.');
            return;
        }

        try {
            const url = 'https://localhost:7037/Calculator/calculate';
            const requestData = {
                Opt1: parseFloat(operand1),
                Operator: operator,
                Opt2: parseFloat(operand2),
            };

            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(requestData),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const responseData = await response.json();
            if (responseData.statusCode === 200) {
                resultElement.textContent = responseData.data;
                console.log(responseData);
            } else {
                alert('Calculation failed: ' + responseData.statusMessage);
            }
        } catch (error) {
            console.error('Fetch error:', error);
        }
    }


    function handleButtonClick(buttonText) {
        if (isNumeric(buttonText)) {
            if (!operator) {
                operand1 = handleNumericInput(operand1, buttonText);
            } else {
                operand2 = handleNumericInput(operand2, buttonText);
            }
        } else if (buttonText === '=') {
            if (operand1 && operator && operand2) {
                calculate(operand1, operator, operand2);
                operand2 = '';
                operator = '';
                operand1 = '';

            }
        } else if (buttonText === 'Clear') {
            resetInput();
        } else if (buttonText === 'DEL') {
            handleBackspace();
        } else if (buttonText === '.') {
            if (!operator) {
                operand1 += buttonText;
            } else {
                operand2 += buttonText;
            }
        }
        else if (buttonText === 'x²') {
            if (!operator) {
                if (operand1 !== "") {
                    operand1 = squared(operand1);
                } else {
                    operand1 = "";
                }
            }
            else {
                if (operand2 !== "") {
                    operand2 = squared(operand2);
                } else {
                    operand2 = "";
                }
            }
        } else if (buttonText === '√x') {
            if (!operator) {
                if (operand1 !== "") {
                    operand1 = squareRoot(operand1);
                } else {
                    operand1 = "";
                }
            }
            else {
                if (operand2 !== "") {
                    operand2 = squareRoot(operand2);
                } else {
                    operand2 = "";
                }
            }
        }
        else {
            if (operand1.length !== 0) {
                operator = buttonText;
            }
        }
        updateDisplay();
    }

    function handleNumericInput(operand, buttonText) {
        if (buttonText === ".") {
            return operand.includes('.') ? operand : operand + buttonText;
        } else {
            if (operand === '0' && buttonText !== ".") {
                return buttonText;
            } else {
                return operand + buttonText;
            }
        }
    }

    function handleBackspace() {
        if (operator && operand2.length > 0) {
            operand2 = backSpace(operand2);
        } else if (operator) {
            operator = '';
        } else if (operand1.length > 0) {
            operand1 = backSpace(operand1);
        }
    }

    const squared = (operand) => {
        return Math.pow(parseFloat(operand), 2).toString();
    }

    const squareRoot = (operand) => {
        return Math.sqrt(parseFloat(operand)).toString();
    }

    document.querySelectorAll('.btn').forEach(button => {
        button.addEventListener('click', function () {
            handleButtonClick(this.textContent);
        });
    });

    function isNumeric(text) {
        return /^\d*\.?\d*$/.test(text);
    }

    function updateDisplay() {
        inputElement.textContent = operand1 + ' ' + operator + ' ' + operand2;
    }
});
