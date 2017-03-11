

function SubprogramNode1() {
    return;
}
function ParallelNode1_0() {
    while(true) {
        SubprogramNode1();
    }
    return;
}
function ParallelNode1_1() {
    SubprogramNode1();
    return;
}
function ParallelNode2_0() {
    SubprogramNode1();
    return;
}
function main() {
    if (condition) {
        Threading.startThread("as", "ParallelNode1_0");
        SubprogramNode1();
        return;
    }
    else {
        Threading.startThread("on", "ParallelNode2_0");
        SubprogramNode1();
        return;
    }
}

