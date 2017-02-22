 

function SubprogramNode1() {
    SubprogramNode2();
    return;
}
function SubprogramNode2() {
    return;
}
function ParallelNode1_0() {
    SubprogramNode1();
    Threading.joinThread("as");
    Threading.joinThread("main");
    return;
}
function ParallelNode2_0() {
    SubprogramNode1();
}
function main() {
    Threading.startThread("on", "ParallelNode1-0");
    Threading.startThread("as", "ParallelNode2-0");
    SubprogramNode2();
}

