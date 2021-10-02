import IGambler from "./gambler";

interface IGamblerDetails extends IGambler {
    id: number;
    balance: number;
    totalWins: number;
}

export default IGamblerDetails;