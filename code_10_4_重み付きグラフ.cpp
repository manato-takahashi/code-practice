#include <iostream>
#include <vector>
using namespace std;

struct Edge {
    int to; // 隣接頂点番号
    long long w; // 重み
    Edge(int to, long long w) : to(to), w(w) { } // 初期化を表すコンストラクタの省略的書き方
};

// 各頂点の隣接リストを辺集合で表す
using Graph = vector<vector<Edge>>;

int main () {
    // 頂点数と辺数
    int N, M;
    cin >> N >> M;

    // グラフ
    Graph G(N);
    for(int i=0; i<M; i++)
    {
        int a, b;
        long long w;
        cin >> a >> b >> w;
        G[a].push_back(Edge(b, w));
    }

    for(int i=0; i<N; i++)
    {
        for(auto e : G[i])
        {
            cout << "(" << i << ", " << e.to << ", " << e.w << ")" << endl;
        }
    }
}