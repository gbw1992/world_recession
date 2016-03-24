/**
 * aqiData，存储用户输入的空气指数数据
 * 示例格式：
 * aqiData = {
 *    "北京": 90,
 *    "上海": 40
 * };
 */
var aqiData  = {};
//var i=0 ;
/**
 * 从用户输入中获取数据，向aqiData中增加一条数据
 * 然后渲染aqi-list列表，增加新增的数据
 */
function addAqiData() {
	var apicity  = document.getElementById('aqi-city-input').value.trim();
	var apivalue = document.getElementById('aqi-value-input').value.trim();
	/*
	*此处参考了其他同学的例子
	*/
	if(!apicity.match(/^[A-Za-z\u4E00-\u9FA5]+$/)){
        alert("城市名必须为中英文字符！")
        return;
    }
    if(!apivalue.match(/^\d+$/)) {
        alert("空气质量指数必须为整数！")
        return;
    }
	aqiData[apicity] = apivalue; //生成二维数组
}

/**
 * 渲染aqi-table表格
 */
function renderAqiList() {
	var aqitab = document.getElementById("aqi-table"); //获取table id
	var items = "<tr><td>城市</td><td>空气质量</td><td>操作</td></tr>";
	for(var x in aqiData){
		items += '<tr><td>'+ x +'</td>'+'<td>'+ aqiData[x]+"</td>"+'<td style="text-align:center"><button type="button" onclick="delBtnHandle(\'' + x + '\')">删除</button></td>';
	}
	aqitab.style.cssText += 'text-align:center'; //添加了一个文字居中的样式 
	aqitab.innerHTML = items;
}

/**
 * 点击add-btn时的处理逻辑
 * 获取用户输入，更新数据，并进行页面呈现的更新
 */
function addBtnHandle() {
  addAqiData();
  renderAqiList();
  //alert("text");
}

/**
 * 点击各个删除按钮的时候的处理逻辑
 * 获取哪个城市数据被删，删除数据，更新表格显示
 */
function delBtnHandle(x) {
  // do sth.
	delete aqiData[x];
	//alert("text");
	renderAqiList();
}

function init() {

  // 在这下面给add-btn绑定一个点击事件，点击时触发addBtnHandle函数
	document.getElementById("add-btn").onclick = addBtnHandle;
  // 想办法给aqi-table中的所有删除按钮绑定事件，触发delBtnHandle函数

}
window.onload = function(){init();}; //当页面加载的时候可以调用某些函数

