import React from "react";

import "./../assets/css/bootstrap.min.css";
import "./../assets/css/font-awesome.min.css";
import "./../assets/css/jquery-ui.css";
import "./../assets/css/main.css";

import Router from "./Router";
import Header from "./shared/Header";

const App = (): JSX.Element => {
    return (
        <>
            <Router />
            <Header />
        </>
    );
};

export default App;
