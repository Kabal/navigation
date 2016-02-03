﻿import Dialog = require('./config/Dialog');
import State = require('./config/State');

class StateContext {
    oldState: State = null;
    oldDialog: Dialog = null;
    oldData: any = {};
    previousState: State = null;
    previousDialog: Dialog = null;
    previousData: any = {};
    state: State = null;
    dialog: Dialog = null;
    data: any = {};
    url: string = null;
    title: string = null;
    crumbTrail: string = null;
    crumbTrailKey: string = null;

    includeCurrentData(data: any, keys?: string[]): any {
        if (!keys) {
            keys = [];
            for (var key in this.data)
                keys.push(key);
        }
        var newData: any = {};
        for (var i = 0; i < keys.length; i++)
            newData[keys[i]] = this.data[keys[i]];
        for (var key in data)
            newData[key] = data[key];
        return newData;
    }

    clear(key?: string) {
        if (key)
            this.data[key] = this.state.defaults[key];
        else {
            for (var dataKey in this.data) {
                this.data[dataKey] = this.state.defaults[dataKey];
            }
        }
    }
}
export = StateContext;
