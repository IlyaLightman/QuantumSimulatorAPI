# QuantumSimulatorAPI
Simple Quantum Simulator API based on Microsoft QDK. Works with the simplest quantum circuits

Now it supports only one POST request - quantumsimulator, that calculates a simple quantum circuit with the instructions you send.
With the request you have to send some JSON body that contains qubits count, repeats count and array of instructions in this format: "<_INSTRUCTION_>(<_prm1_>, <_prm2_>, ...)"

Example of data to calculate Quantum Teleportation cicuit:
```
{
  "instructions": [
    "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)",
    "H(q3)", "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)",
    "IFM(q2,One)", "X(q3)", "IFM(q1,One)", "Z(q3)",
  ],
  "qubits": 3,
  "repeats": 1000
}
```
Request with this body will return an int array with the lenght of qubits count (here it's three). Every its element represents how many times qubit (for 0 array element it's q1 qubit) after measurment equals One.

Supported parameters in instrucitons it's qubits: *q1, q2, ...* (For example, if there are two qubits, you are able to work with it indicating as q1 and q2), and Zero/One state of qubit (for assignment or measurment).

There are some instructions:
* SET(<_qubit_>,<_Zero/One_>) - set the qubit in the choisen state
* IFM(<_qubit_>,<_Zero/One_>) - if qubit after measure will in the choisen state, the next instruction after IFM will perform, else - won't
* CNOT(<_qubit1_>,<_qubit2_>) - CNOT gate, where qubit1 - controlling qubit
* H(<_qubit_>) - Hadamar gate
* X(<_qubit_>), Y(<_qubit_>), Z(<_qubit_>) - Pauli gates
