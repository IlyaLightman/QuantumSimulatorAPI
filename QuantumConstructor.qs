namespace QuantumSimulatorAPI {

	open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

	operation Set ( q1: Qubit, desired: Result) : Unit
    {
        let current = M(q1);
        if (desired != current)
        {
            X(q1);     
		}

        // Message("Set Function used");
	}

    // Special None Operations

    operation none (q : Qubit) : Unit {
        // Message("None Operation was called");
	}

    operation doubleNone (qubits : (Qubit, Qubit)) : Unit {
        // Message("Double None Operation was called");
	}

    // Decorated Gates

    operation _H (q : Qubit) : Unit {
        H(q);
        // Message("H Gate Used");
	}

    operation _X (q : Qubit) : Unit {
        X(q);
        // Message("X Gate Used");
	}

    operation _Y (q : Qubit) : Unit {
        Y(q);
        // Message("Y Gate Used");
	}

    operation _Z (q : Qubit) : Unit {
        Z(q);
        // Message("Z Gate Used");
	}

    operation _CNOT (qubits : (Qubit, Qubit)) : Unit {
        CNOT(qubits);
        // Message("CNOT Gate Used");
	}

    // Operation with one Qubit
    function SingleGates(op : String) : (Qubit => Unit) {
        if (op == "H") {
            return _H;
		} elif (op == "X") {
            return _X;
		} elif (op == "Y") {
            return _Y;
        } elif (op == "Z") {
            return _Z;
		} else {
            return none;
		}
	}

    // Operations with two Qubits
    function DoubleGates(op: String) : ((Qubit, Qubit) => Unit) {
        if (op == "CNOT") {
            return _CNOT;  
		} else {
            return doubleNone;  
		}
	}

    // data = ['H(q1)', 'CNOT(q1,q2)', 'IFM(q3,One)', 'Z(q1)', X(q3)]
    // ops = ['H', 'CNOT', 'IFM', 'Z', 'X']
    // prm = [0, 0, 1, 2, 1, 0, 2]
    operation Constructor (qbts : Int, repeats: Int, ops : String[], prm : Int[]) : Int[] {
        // let OperationsControllers = [SingleOperations, DoubleOperations];

        mutable toReturn = new Int[qbts];

        for (r in 0..(repeats - 1)) {
            mutable operations = ops;
            mutable index = 0;

            using (qubits = Qubit[qbts]) {
                for (op in 0..Length(ops) - 1) {
                    if (operations[op] == "IFM") {
                        mutable localResult = Zero;
                        if (prm[index + 1] == 1) {
                            set localResult = One;           
					    }

                        if (M(qubits[prm[index]]) != localResult) {
                            // next operation is none (single or double)

                            if (operations[op + 1] == "CNOT") {
                                set operations w/= op + 1 <- "doubleNone";
						    } else {
                                set operations w/= op + 1 <- "none";
						    }
					    }

                        set index += 2;
                    } elif (operations[op] == "SET") {
                        let results = [Zero, One];

                        Set(qubits[prm[index]], results[prm[index + 1]]);

                        set index += 2;
				    } elif (operations[op] == "CNOT") {
                        let o = DoubleGates(operations[op]);
                        o(qubits[prm[index]], qubits[prm[index + 1]]);

                        set index += 2;
				    } else {
                        let o = SingleGates(operations[op]);
                        o(qubits[prm[index]]);

                        set index += 1;
				    }
			    }

                for (q in 0..qbts - 1) {
                    if (M(qubits[q]) == One) {
                        set toReturn w/= q <- toReturn[q] + 1;
				    } 
			    }

                // Message($"{index}");

                // return str;
		    }
	    }

        return toReturn;
	}
}