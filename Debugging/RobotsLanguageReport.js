

function ParallelNode1_0() {
    Subprogram();
    return;
}
function ParallelNode1_1() {
    Subprogram();
    return;
}
function main() {
    if (condition) {
        Threading.startThread("on", "ParallelNode1_0");
        Subprogram();
        return;
    }
    else {
        Subprogram();
        return;
    }
}

