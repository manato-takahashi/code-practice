#include <bits/stdc++.h>
using namespace std;

const long long INF = 1LL << 60; // 十分大きい値とする (ここでは 2^60)


template<class T> bool chmin(T& a, T b) {
    if(a > b) {
        a = b;
        return true;
    }
    else return false;
}


int main () {
    int H, W;
    cin >> H >> W;
    vector<vector<char>> c(H, vector<char>(W));

    // 入力の受け取り
    for(int i=0; i<H; i++) {
        for(int j=0; j<W; j++) {
            cin >> c[i][j];
        }
    }

    // スタートとゴールのマス
    int sx, sy, gx, gy;
    for(int i=0; i<H; i++) {
        for(int j=0; j<W; j++) {
            if(c[i][j] == 's') {
                sx = i;
                sy = j;
            }
            if(c[i][j] == 'g') {
                gx = i;
                gy = j;
            }
        }
    }

    // // ダイクストラ法：線形探索Ver.（これだとTLE、線形探索して最小値を見つけようとしているところがボトルネックになっていると思われる）
    // vector<vector<bool>> used(H, vector<bool>(W, false)); // true: すでに使われた
    // vector<vector<long long>> dist(H, vector<long long>(W, INF));  // INF で初期化
    // dist[sx][sy] = 0; // スタートは0
    // vector<int> dx = {1, 0, -1, 0};
    // vector<int> dy = {0, 1, 0, -1};

    // for(int i=0; i<H*W; i++) {
    //     long long min_dist = INF;
    //     int min_v = -1;
    //     for(int v=0; v<H*W; v++) {
    //         if(!used[v/W][v%W] && dist[v/W][v%W] < min_dist) {
    //             min_dist = dist[v/W][v%W];
    //             min_v = v;
    //         }
    //     }

    //     if(min_v == -1) break;

    //     // min_vを始点として各辺を緩和する
    //     for(int k=0; k<4; k++) {
    //         int nx = min_v/W + dx[k];
    //         int ny = min_v%W + dy[k];
    //         if(nx < 0 || nx >= H || ny < 0 || ny >= W) continue;

    //         chmin(dist[nx][ny], dist[min_v/W][min_v%W] + (c[nx][ny] == '#' ? 1 : 0));
    //     }
    //     used[min_v/W][min_v%W] = true;
    // }

    // ダイクストラ法：ヒープを用いるVer.
    vector<vector<long long>> dist(H, vector<long long>(W, INF));  // INF で初期化
    dist[sx][sy] = 0; // スタートは0
    vector<int> dx = {1, 0, -1, 0};
    vector<int> dy = {0, 1, 0, -1};

    // (d[v], v) のペアを要素としたヒープを作る
    priority_queue<pair<long long, int>, vector<pair<long long, int>>, greater<pair<long long, int>>> que;
    que.push(make_pair(dist[sx][sy], sx*W+sy));

    // ダイクストラ法の反復を開始
    while (!que.empty()) {
        // v: 使用済みでない頂点のうち d[v] が最小の頂点
        // d: v に対するキー値
        int v = que.top().second;
        long long d = que.top().first;
        que.pop();

        // d > dist[v] は，(d, v) がゴミであることを意味する
        if (d > dist[v/W][v%W]) continue;

        // 頂点 v を始点とした各辺を緩和
        for(int k=0; k<4; k++) {
            int nx = v/W + dx[k];
            int ny = v%W + dy[k];
            if(nx < 0 || nx >= H || ny < 0 || ny >= W) continue;

            if(chmin(dist[nx][ny], dist[v/W][v%W] + (c[nx][ny] == '#' ? 1 : 0))) {
                // 更新があるならヒープに新たに挿入
                que.push(make_pair(dist[nx][ny], nx*W+ny));
            }
        }
    }



    // 結果出力
    if(dist[gx][gy] <= 2) cout << "YES" << endl;
    else cout << "NO" << endl;
    // cout << dist[gx][gy] << endl;

    
}